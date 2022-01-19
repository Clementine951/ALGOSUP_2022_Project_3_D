namespace synthesizer

open System
open Amplitude 


module WaveGen =
    let calcSin sampleRate time freq amp bol=
        let trig = 1
        let t = 1. + (1./sampleRate) // This is the frequency where each point will be created
        let N = sampleRate * time // This is the number of points created
        let omega = 2. * System.Math.PI * freq // We calculate the period


        let points = [(0.)..t..N] // This is where the points are stored
        let points = points |> List.map(fun x -> amp * sin(omega*x) ) // This is used to calculate each coordinates of each points
        // printfn "%O" testpoint.Length²
        if bol = true then // bol arg is here to chose if you want to use this fuction
           Amplitude.Amp(points, 4.0,t,N,freq,omega,trig)
           else
           points

    let calcSquare sampleRate time freq amp bol=
        let trig = 2
        let t = 1. + (1./sampleRate)
        let N = sampleRate * time
        let omega = 2. * System.Math.PI * freq

        let points = [(0.)..t..N]
        let points = points |> List.map(fun x -> amp * float (sign (sin (x * omega))) )
        if bol = true then // bol arg is here to chose if you want to use this fuction
            Amplitude.Amp(points, 4.0,t,N,freq,omega,trig)
            else
            points


    let calcTri sampleRate time freq amp bol=
        let trig = 3
        let t = 1. + (1./sampleRate) // This is the frequency where each point will be created
        let N = sampleRate * time  // This is the number of points created
        let omega = 2. * System.Math.PI * freq // We calculate the period

        let points = [(0.)..t..N] // This is where the points are stored
        let points = points |> List.map(fun x ->  amp * 2. * asin (sin (2. * System.Math.PI * t * freq)) / System.Math.PI ) // This is used to calculate each coordinates of each points
        // printfn "%O" testpoint.Length
        if bol = true then // bol arg is here to chose if you want to use this fuction
            Amplitude.Amp(points, 4.0,t,N,freq,omega,trig)
            else
            points


    let calcSaw sampleRate time freq amp bol=
        let trig = 4
        let t = 1. + (1./sampleRate) // This is the frequency where each point will be created
        let N = sampleRate * time // This is the number of points created
        let omega = 2. * System.Math.PI * freq // We calculate the period

        let points = [(0.)..t..N]
        let points = points |> List.map(fun x ->  amp * 2. * (x * freq - floor (0.5 +  x * freq)) )
        if bol = true then // bol arg is here to chose if you want to use this fuction
            Amplitude.Amp(points, 4.0,t,N,freq,omega,trig)
            else
            points
    



    let calcSinFlange sampleRate time freq amp bol=
        let trig = 5
        let t = 1. + (1./sampleRate)            // Calculate the incrementation for the list based on the sampleRate
        let N = sampleRate * time               // Define how much Samples we need for the sound
        let omega = 2. * System.Math.PI+0.2 * freq  // Omega is a part of the Calculation of the Equation

        let points = [(0.)..t..N]               // Create the list with all X axis value
        let points = points |> List.map(fun x -> amp * sin(omega*x*10.005) )   // Apply the formula to all x value to have Y axis values
        if bol = true then // bol arg is here to chose if you want to use this fuction
            Amplitude.Amp(points, 4.0,t,N,freq,omega,trig)
            else
            points