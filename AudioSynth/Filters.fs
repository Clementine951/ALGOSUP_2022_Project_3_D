namespace synthesizer


open System
open System.IO
open System.Threading

open WaveGen
open NoteToHz



module Filter =
    let waveAmp =
        let a = 1+1
        a
    let sinFlange sampleRate time freq amp =
        let wave = WaveGen.calcSin sampleRate time freq amp
        let flange = WaveGen.calcSinFlange sampleRate time freq amp
        let sumList = List.map2 (fun x y -> (x + y)/2.) wave flange
        sumList