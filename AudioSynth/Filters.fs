namespace synthesizer


open System
open System.IO
open System.Threading

open WaveGen
open NoteToHz


module Filters =

    let chords wave1 wave2 =
        let sumList = List.map2 (fun x y -> (x + y)/2.) wave1 wave2
        sumList
    
    let amplitude (initialList:list<float>) (amp:float) =
        let returnList = List.map (fun x -> x*amp) initialList
        returnList
    
    
    // Stay the list below or equal to the amp value and return a new list
    let overdriven (list:float list) (amp:float) =
        let lenght = list.Length
        let returnList = [for i in 0..lenght-1 do if list.[i]>= amp then amp else list.[i]]
        returnList
      // creat some list who begin in different place and amplitude and return in list of averge of list
    let rev(list:float list) =
        let lenght = list.Length       
        let rev = [for i in 0..lenght-1 do list.[i]]       
        let rev1 = [for i in 0..lenght-1 do if i >= (lenght-1)/6 then  list.[i]/2. else 0.]       
        let rev2 = [for i in 0..lenght-1 do if i >= (lenght-1)/5 then  list.[i]/3. else 0.]       
        let rev3 = [for i in 0..lenght-1 do if i >= (lenght-1)/4 then  list.[i]/4. else 0.]       
        let rev4 = [for i in 0..lenght-1 do if i >=(lenght-1)/3 then  list.[i]/5. else 0.]       
        let rev5 = [for i in 0..lenght-1 do if i >=(lenght-1)/2  then  list.[i]/6. else 0.]       
        let mergeRev = [for i in 0..lenght-1 do (rev.[i]+rev1.[i]+rev2.[i]+rev3.[i]+rev4.[i]+rev5.[i])/6.]
        mergeRev
         
        // reverse list
    let reverse list=
        let rec loop acc = function
        | [] -> acc
        | head :: tail -> loop(head::acc) tail
        loop[] list
        // return reverb list
    let reverb list =
       let init =  rev list
       let reverse = reverse init
       reverse
    
    // Create a flange effect
    let flange (wave: float list)=

        let lenght = wave.Length // This function check the length of the wave
        let subWave = [for i in 0..lenght-1 do wave.[i] * -1.] // This inverts all the values of the wave
        // let test =  for i in 0..lenght-1 do
        //             printfn"wave %A" wave.[i]
        //             printfn"subWave %A" subWave.[i]
        subWave
        
        
        
        
    let echo (initialList:list<float>) (delay:float) (amp:float) (repeat:float) =

        let repeat = int repeat
        let tmpList = WaveGen.calcSin 44100. delay 0. 0. // Define the silence time based on delay

        let returnFullList = [
            yield initialList // Start by returning the base sound
            for i = 1 to repeat do  // Then return each echo effect
                let i = float i

                let returnList = tmpList @ (amplitude initialList ( amp / i)) // calling th amp function to reduce the sound each for each echo
                yield returnList
        ]
        let returnFullList = List.concat returnFullList // Fuse all list returned into only one
        returnFullList
        

    let bothModulation (wave: list<float>) amp highFreq lowFreq =
        let N = float wave.Length
        let t = 1. + (1./44100.)
        let points = [(0.) .. t .. N+1.]
        let transform x =
            amp * 
            Math.Sin ( 2. * System.Math.PI * highFreq * x * highFreq * Math.Cos (2. * System.Math.PI * lowFreq * x))
        let points = points |> List.map transform
        let sumList = List.map2 (fun x y -> x * y) wave points
        sumList

    let amplitudeModulation (wave: list<float>) amp freq =
        let N = float wave.Length
        let t = 1. + (1./44100.)
        let points = [(0.) .. t .. N+1.]
        let omega = 2. * System.Math.PI * freq
        let transform x =
            amp * (Math.Sin ( omega * x  ) * Math.Sin (omega * x))
        let points = points |> List.map transform
        List.map (fun x -> printfn "%O" x) points |> ignore
        let sumList = List.map2 (fun x y -> x * y) wave points
        sumList

    let frequencyModulation (wave: list<float>) highFreq lowFreq =
        let N = float wave.Length
        let t = 1. + (1./44100.)
        let points = [(0.) .. t .. N+1.]
        let transform x =
            Math.Sin ( 2. * System.Math.PI * highFreq * x  * highFreq * Math.Cos (2. * System.Math.PI * lowFreq * x))
        let points = points |> List.map transform
        let sumList = List.map2 (fun x y -> x * y) wave points
        sumList
