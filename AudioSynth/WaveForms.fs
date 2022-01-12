namespace test

open System

module WaveGen =
    let calcSin sampleRate time freq amp =

        let t = 1. + (1./sampleRate)
        let N = sampleRate * time
        let omega = 2. * System.Math.PI * freq


        let points = [(0.)..t..N]
        let points = points |> List.map(fun x -> amp * sin(omega*x) )
        // printfn "%O" testpoint.Length
        points
    let calcSquare sampleRate time freq amp =

        let t = 1. + (1./sampleRate)
        let N = sampleRate * time
        let omega = 2. * System.Math.PI * freq


        let points = [(0.)..t..N]
        let points = points |> List.map(fun x -> amp * float (sign (sin (x * omega))) )
        // printfn "%O" testpoint.Length
        points


    let calcTri sampleRate time freq amp =

        let t = 1. + (1./sampleRate)
        let N = sampleRate * time
        let omega = 2. * System.Math.PI * freq

        let points = [(0.)..t..N]
        let points = points |> List.map(fun x ->  amp * 2. * asin (sin (x*omega)) / System.Math.PI )
        // printfn "%O" testpoint.Length
        points

    let calcSaw sampleRate time freq amp =

        let t = 1. + (1./sampleRate)
        let N = sampleRate * time
        let omega = 2. * System.Math.PI * freq

        let points = [(0.)..t..N]
        let points = points |> List.map(fun x ->  amp * 2. * (x * freq - floor (0.5 +  x * freq)) )
        // printfn "%O" testpoint.Length
        points