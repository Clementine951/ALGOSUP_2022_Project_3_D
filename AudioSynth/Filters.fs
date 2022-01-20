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
    // let sinFlange sampleRate time freq amp =
    //     let wave = WaveGen.calcSin sampleRate time freq amp
    //     let flange = WaveGen.calcSinFlange sampleRate time freq amp
    //     let sumList = List.map2 (fun x y -> (x + y)/2.) wave flange
    //     sumList
    

    let amplitude (initialList:list<float>) (amp:float) =
        let returnList = List.map (fun x -> x*amp) initialList
        returnList


    let echo (initialList:list<float>) (delay:float) (amp:float) (repeat:float) =
        //for i = 1 to repeat do
        let delaySample = delay * repeat
        let tmpList = WaveGen.calcSin 44100 delay 0. 0.
        let baseList = initialList @ tmpList
        let newList = amplitude (tmpList @ initialList) amp
        // ADD FUNCTION TO REDUCE VOLUME / AMPLITUDE
        let interate = newList.Length
        printfn "initial %O" initialList.Length
        printfn "tmp lenght %O" tmpList.Length
        printfn "new list %O" newList.Length
        printfn "Interate %O" interate
        let returnList = [
            for i = 0 to interate-1 do
                // printfn "%O" i
                if newList.Item(i) = 0. then yield baseList.Item(i)
                elif i >= initialList.Length then yield newList.Item(i)
                else 
                    yield ((newList.Item(i) + baseList.Item(i))/2.)
        ]
        returnList



    
        

            