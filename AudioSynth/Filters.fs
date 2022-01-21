namespace synthesizer


open System
open System.IO
open System.Threading

open WaveGen
open NoteToHz


module Filters =
    
    //let sinFlange sampleRate time freq amp =
       // let wave = WaveGen.calcSin sampleRate time freq amp
       // let flange = WaveGen.calcSinFlange sampleRate time freq amp
        //let sumList = List.map2 (fun x y -> (x + y)/2.) wave flange

    let amplitude (initialList:list<float>) (amp:float) =
        let returnList = List.map (fun x -> x*amp) initialList
        returnList
    
    
    // Stay the list below or equal to the amp value and return a new list
    let Overdriven (list:float list,amp:float) =
        let lenght = list.Length
        let returnList = [for i in 0..lenght-1 do if list.[i]>= amp then amp else list.[i]]
        returnList
      

       

    // let flange wave (t:float, N:float)=

    //     let subWave = [(0.)..t..N]
    
    //     let subWave = subWave |> List.map(fun x -> wave * -1.)
    //     subWave