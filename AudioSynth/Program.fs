// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
namespace synthesizer

open System
open System.IO
open System.Threading

open WaveGen
open PlaySynth
open NoteToHz

module Main =

    let inputNote = [|
        // ( "NOTE":string, OCTAVE:float, AMPLITUDE:float PLAYTIME:float,)
        ("G", 3., 0.9, 0.9)
        ("G#", 3., 0.9, 0.9)
        ("G", 3., 0.9, 0.9)
        ("A", 3., 0.9, 0.9)
        ("B", 3., 0.9, 0.9)
        ("A", 3., 0.9, 0.9)
        ("G", 3., 0.9, 0.9)
        ("B", 3., 0.9, 0.9)
        ("A", 3., 0.9, 0.9)
        ("C", 3., 0.9, 0.9)
        ("G", 3., 0.9, 0.9)
    |]
//                                    List of notes  Samplerate
    let normalWave = noteListToFloatList inputNote 44100.

    // let normalWave = calcSin 44100. 1. 130.9 0.9

    // let test = NoteToHz.convert "A" 6
    //let normalWave = Filter.sinFlange 44100. 10. 40000.  1.

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



    PlaySynth.playSound ("test.wav" ,true ,float32(2.0))
     // return an integer exit code
