// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// y sin (g X )
// y = amplitude height of the function
// g = Multiplier of Period
// Period = g x 2 pi
namespace test

open System
open System.IO
open System.Threading

open WaveGen
open playSynth

module main =
    // let normalWave = WaveGen.calcSin SampleRate Time Frequency Amplitude
    //                                     Float   Float   Float   Float

    // let normalWave = WaveGen.calcSin 44100. 2. 440. 1.
    // let normalWave = WaveGen.calcSaw 44100. 2. 440. 1.
    // let normalWave = WaveGen.calcTri 44100. 2. 440. 1.

    //---------------------------------
    // Sound like 'Au clair de la lune'
    //---------------------------------
    // let normalWave = WaveGen.calcSin 44100. 0.0 523.3 0.
    //                 // |> List.append(WaveGen.calcSin 44100. 0.3 523. 0.6)
    //                 |> List.append(WaveGen.calcSin 44100. 0.3 523. 0.6)
    //                 |> List.append(WaveGen.calcSin 44100. 0. 523. 0.)
    //                 |> List.append(WaveGen.calcSin 44100. 0.3 523. 0.6)
    //                 |> List.append(WaveGen.calcSin 44100. 0.3 587. 0.6)
    //                 |> List.append(WaveGen.calcSin 44100. 0.3 659. 0.6)
    //                 |> List.append(WaveGen.calcSin 44100. 0.3 523. 0.6)
    //                 |> List.append(WaveGen.calcSin 44100. 0.6 659. 0.6)
    //                 |> List.append(WaveGen.calcSin 44100. 0.4 587. 0.6)
    //                 |> List.append(WaveGen.calcSin 44100. 0.3 523. 0.6)
    //                 |> List.append(WaveGen.calcSin 44100. 0. 523. 0.)
    //                 |> List.append(WaveGen.calcSin 44100. 0.3 523. 0.6)
    //                 |> List.append(WaveGen.calcSin 44100. 0. 523. 0.)
    //                 |> List.append(WaveGen.calcSin 44100. 0.3 523. 0.6)
    
    let normalWave = WaveGen.calcSin 44100. 1. 523.3 0.6

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

        writer.Write("data"B)
        writer.Write(data.Length)
        writer.Write(data)
    let sample x = (x + 1.)/2. * 255. |> byte
    let data = normalWave 
                |> List.map sample 
                |> Microsoft.FSharp.Collections.List.toArray
    // printfn "Data: %A" data
    let stream = File.Create(@"test.wav")
    write stream data
    playSynth.PlaySound "test.wav" false 
     // return an integer exit code
