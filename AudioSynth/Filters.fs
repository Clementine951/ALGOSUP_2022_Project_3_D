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

        let repeat = int repeat
        let tmpList = WaveGen.calcSin 44100 delay 0. 0. // Define the silence time based on delay

        let returnFullList = [
            yield initialList // Start by returning the base sound
            for i = 1 to repeat do  // Then return each echo effect
                let i = float i

                let returnList = tmpList @ (amplitude initialList ( amp / i)) // calling th amp function to reduce the sound each for each echo
                yield returnList
        ]
        let returnFullList = List.concat returnFullList // Fuse all list returned into only one
        returnFullList



    
        

            