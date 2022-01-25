namespace synthesizer

open System
open System.IO
open System.Threading

open WaveGen
open NoteToHz


let flange (wave: float list)=

        let lenght = wave.Length 
        let subWave = [for i in 0..lenght-1 do wave.[i] * -1.]
        // let test =  for i in 0..lenght-1 do
        //             printfn"wave %A" wave.[i]
        //             printfn"subWave %A" subWave.[i]
        subWave