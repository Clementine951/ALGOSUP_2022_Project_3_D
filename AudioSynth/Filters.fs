namespace synthesizer


open System
open System.IO
open System.Threading
open MathNet.Filtering


open WaveGen
open NoteToHz


module Filters =
    
    //let sinFlange sampleRate time freq amp =
       // let wave = WaveGen.calcSin sampleRate time freq amp
       // let flange = WaveGen.calcSinFlange sampleRate time freq amp
        //let sumList = List.map2 (fun x y -> (x + y)/2.) wave flange
    

    // let flange (wave:list<float>) time=
    //     let mutable second = wave 

    //     while (second.[time] <> 0.) do
    //         printfn "hey"
    //         second |> List.append [0.]
    //         printfn "hello"
        
    //     let sumList = List.map2 (fun x y -> (x + y)/2.) wave second
    //     sumList

    let amplitude (initialList:list<float>) (amp:float) =
        let returnList = List.map (fun x -> x*amp) initialList
        returnList
    
    
    // Stay the list below or equal to the amp value and return a new list
    let Overdriven (list:float list,amp:float) =
        let lenght = list.Length
        let returnList = [for i in 0..lenght-1 do if list.[i]>= amp then amp else list.[i]]
        returnList
      // creat some list who begin in different place and amplitude and return in list of averge of list
    let Rev(list:float list) =
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
    let Reverse list=
        let rec loop acc = function
        | [] -> acc
        | head :: tail -> loop(head::acc) tail
        loop [] list
        // return reverb list
    let Reverb list =
       let init =  Rev list
       let reverse = Reverse init
       reverse
    let spectroscope (list:float list) =
       
       let lenght = list.Length
       let mutable trig = 0
       let mutable t = 0.
       let mutable check = 0.
       
       let periode = // find period of list
           for i in 0..lenght-1 do
               
               
               
               if i < lenght-1 && i > 0 then
                
                if trig >= 1 && trig <= 2 then
                    t <- t + 0.0001
                   
                if trig = 2 then
                    
                    
                    trig <- trig + 1
                   
                  elif list.[i] > list.[i+1] && list.[i] >= list.[i-1] then
                    
                    trig <-trig + 1
                    check <- check + list.[i] - check

                    
                    
                    if check > list.[i] then // trig work only  highest value
                     trig <- trig - 1
                     
                     
                     
                    
                    
           
           t  
       let getFrequency =
       
        1./ periode
       getFrequency
    
    let LowPass (list: float list, fcut: float, order: int) = // return list with Lowpass Filter
        let fs = spectroscope(list)
        let lowPass =  OnlineFilter.CreateLowpass(ImpulseResponse.Finite,fs,fcut,order)
        let array = list |> List.toArray
        let filtered = array |> lowPass.ProcessSamples
        let reList = filtered |> Array.toList
       // printfn"list %A" list
       // printf"lowPass %A" reList
        reList            
       
    let HighPass (list: float list, fcut: float, order: int) = // return list with Highpass Filter
        let fs = spectroscope(list)
        let highPass =  OnlineFilter.CreateHighpass(ImpulseResponse.Finite,fs,fcut,order)
        let array = list |> List.toArray
        let filtered = array |> highPass.ProcessSamples
        let reList = filtered |> Array.toList
       // printfn"list %A" list
       // printf"highPass %A" reList
        reList            
    // let flange wave (t:float, N:float)=

    //     let subWave = [(0.)..t..N]
    
    //     let subWave = subWave |> List.map(fun x -> wave * -1.)
    //     subWave