namespace synthesizer
open System
open System.IO

module save = 
    let sample x = (x + 1.)/2. * 255. |> byte


    let floatToByte wave =
        let data = wave
                    |> List.map sample 
                    |> Microsoft.FSharp.Collections.List.toArray
        data



    let write stream (data:List<float>) =

        let data = floatToByte data

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
