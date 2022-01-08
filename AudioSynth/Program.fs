// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// y sin (g X )
// y = amplitude height of the function
// g = Multiplier of Period
// Period = g x 2 pi

open System
open System.IO


// Define a function to construct a message to print
let calcSin y m a xMultiplier = // Y = prescision, a = amplitude, m = period multiplier
    // a sin ( m x ) 
    
    // System.IEnumerable
    //let m = float(m)
    let pointsNumbers = (m / y)

    let pointsNumbers =  int (pointsNumbers)

    let m = int(m)
    let xMultiplier = int (xMultiplier)

    
    let mutable pointsList = [
    for j = 0 to xMultiplier do
        for i = 0 to ((314/2) * m) do

            let pointsNumbers = (float pointsNumbers)
            let m = float(m)
            let i = (float i)

            let xCoord = ((i * (2.*y)) /pointsNumbers) + (float j * 3.14)

            // printfn "X : %O" xCoord

            let yCoord =  a * sin (m * xCoord)
            // printfn "Y : %O" yCoord


            let yCoord = (yCoord + 1.)/2. * 255.
            let byteY = byte(yCoord)
            // printfn "%A" byteY


            // let pointsList = pointsList 
            //                |> List.append yCoord
            // printfn "%A" pointsList
            yield yCoord
    ]

    pointsList

// let calcSquare y m a = // Y = prescision, a = amplitude, m = period multiplier
//     // a sin ( m x ) 

//     let pointsList = calcSin y m a
//     for i in pointsList do
//         let y = snd(i)

//         let snd(i) = if y > 0 then a else -a
//         pointsList
//     pointsList
//         //printfn "%O" i

//     pointsList
    

[<EntryPoint>]
let main argv =
    let normalWave = calcSin 0.1 1. 8. 1000.

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
        let sampleRate = 8000 in writer.Write(sampleRate)
        let byteRate = sampleRate in writer.Write(byteRate)
        let blockAlign = 1s in writer.Write(blockAlign)
        let bitsPerSample = 8s in writer.Write(bitsPerSample)
        // data
        writer.Write("data"B)
        writer.Write(data.Length)
        writer.Write(data)
    let sample x = (x + 1.)/2. * 255. |> byte
    let data = normalWave |> List.map (fun x -> byte x)
    let data =  Microsoft.FSharp.Collections.List.toArray data
    // printfn "Data: %A" data
    let stream = File.Create(@"test.Wav")
    write stream data
    0 // return an integer exit code
