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