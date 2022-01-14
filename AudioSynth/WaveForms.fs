namespace test

open System

module WaveGen =
    let calcSin sampleRate time freq amp =

        let t = 1. + (1./sampleRate)            // Calculate the incrementation for the list based on the sampleRate
        let N = sampleRate * time               // Define how much Samples we need for the sound
        let omega = 2. * System.Math.PI * freq  // Omega is a part of the Calculation of the Equation

        let points = [(0.)..t..N]               // Create the list with all X axis value
        let points = points |> List.map(fun x -> amp * sin(omega*x) )   // Apply the formula to all x value to have Y axis values
        points


    let calcSquare sampleRate time freq amp =

        let t = 1. + (1./sampleRate)
        let N = sampleRate * time
        let omega = 2. * System.Math.PI * freq

        let points = [(0.)..t..N]
        let points = points |> List.map(fun x -> amp * float (sign (sin (x * omega))) )
        points


    let calcTri sampleRate time freq amp =

        let t = 1. + (1./sampleRate)
        let N = sampleRate * time
        let omega = 2. * System.Math.PI * freq

        let points = [(0.)..t..N]
        let points = points |> List.map(fun x ->  amp * 2. * asin (sin (x*omega)) / System.Math.PI )
        points

    let calcSaw sampleRate time freq amp =

        let t = 1. + (1./sampleRate)
        let N = sampleRate * time

        let points = [(0.)..t..N]
        let points = points |> List.map(fun x ->  amp * 2. * (x * freq - floor (0.5 +  x * freq)) )
        points