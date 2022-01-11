// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// y sin (g X )
// y = amplitude height of the function
// g = Multiplier of Period
// Period = g x 2 pi

open System
open System.IO


// Define a function to construct a message to print
// let calcSin y a xMultiplier = // Y = prescision, a = amplitude, m = period multiplier
    // let pointsNumbers = (xMultiplier / y)

    // let pointsNumbers =  int (pointsNumbers)
    // let m = int(xMultiplier)
    // let xMultiplier = int (xMultiplier)



// let sampleRate = 44100. 
// let time = 2.
// let freq = 12000.


let calcSin sampleRate time freq =

    let t = 1. + (1./sampleRate)
    let N = sampleRate * time
    let omega = 2. * System.Math.PI * freq


    let points = [(0.)..t..N]
    let points = points |> List.map(fun x -> sin(omega*x) )
    // printfn "%O" testpoint.Length

    points




// // let calcSquare y m a = // Y = prescision, a = amplitude, m = period multiplier
// //     // a sin ( m x ) 

// //     let pointsList = calcSin y m a
// //     for i in pointsList do
// //         let y = snd(i)

// //         let snd(i) = if y > 0 then a else -a
// //         pointsList
// //     pointsList
// //         //printfn "%O" i

// //     pointsList
    
    
[<EntryPoint>]
let main argv =
    //let normalWave = calcSin 0.1 0.5 44.

    //let squareWave = calcSquare 0.1 2. 2.
    
    // printfn "Normal Wave : %A" normalWave

    /// Write WAVE PCM soundfile (8KHz Mono 8-bit)
    let write stream (data:byte[]) =
        use writer = new BinaryWriter(stream)
        // RIFF
        writer.Write("RIFF"B)
        let size = 36 + data.Length in writer.Write(size)
        writer.Write("WAVE"B)
        // fmt
        writer.Write("fmt "B)
        let headerSize = 16 in writer.Write(headerSize)
        let pcmFormat = 1s in writer.Write(pcmFormat)
        let mono = 1s in writer.Write(mono)
        let sampleRate = 44100 in writer.Write(sampleRate)
        let byteRate = sampleRate in writer.Write(byteRate)
        let blockAlign = 1s in writer.Write(blockAlign)
        let bitsPerSample = 8s in writer.Write(bitsPerSample)



        // // fmt
        // writer.Write("fmt "B)
        // writer.Write(16) // Header size
        // writer.Write(pcmFormat)
        // writer.Write(nbChannels)
        // writer.Write(sampleRate)
        // writer.Write(byteRate)
        // writer.Write(blockAlign)
        // writer.Write(bitsPerSample)
        // data
        writer.Write("data"B)
        writer.Write(data.Length)
        writer.Write(data)
    let sample x = (x + 1.)/2. * 255. |> byte
    let data = calcSin 44100. 2. 440. |> List.map sample
    let data =  Microsoft.FSharp.Collections.List.toArray data
    // printfn "Data: %A" data
    let stream = File.Create(@"test.wav")
    write stream data
    0 // return an integer exit code
