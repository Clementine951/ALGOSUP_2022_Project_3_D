namespace synthesizer

open System

module WaveGen =
    module WaveGen =
    let calcSin sampleRate time freq amp =

        let t = 1. + (1./sampleRate) // This is the frequency where each point will be created
        let N = sampleRate * time // This is the number of points created
        let omega = 2. * System.Math.PI * freq // We calculate the period


        let points = [(0.)..t..N] // This is where the points are stored
        let points = points |> List.map(fun x -> amp * sin(omega*x) ) // This is used to calculate each coordinates of each points
        // printfn "%O" testpoint.Length²
        points



    let calcTri sampleRate time freq amp =

        let t = 1. + (1./sampleRate) // This is the frequency where each point will be created
        let N = sampleRate * time  // This is the number of points created
        let omega = 2. * System.Math.PI * freq // We calculate the period

        let points = [(0.)..t..N] // This is where the points are stored
        let points = points |> List.map(fun x ->  amp * 2. * asin (sin (2. * System.Math.PI * t * freq)) / System.Math.PI ) // This is used to calculate each coordinates of each points
        // printfn "%O" testpoint.Length
        points


    let calcSaw sampleRate time freq amp =

        let t = 1. + (1./sampleRate) // This is the frequency where each point will be created
        let N = sampleRate * time // This is the number of points created
        let omega = 2. * System.Math.PI * freq // We calculate the period

        let points = [(0.)..t..N] // This is the number of points created
        let points = points |> List.map(fun x ->  amp * 2. * (t * freq - floor (0.5 +  t * freq)) ) // This is used to calculate each coordinates of each points
        // printfn "%O" testpoint.Length
        points