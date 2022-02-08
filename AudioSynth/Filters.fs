namespace synthesizer


open System
open System.IO
open System.Threading
open MathNet.Filtering


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
        loop [] list
        // return reverb list
    let reverb list =
       let init =  rev list
       let reverse = reverse init
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

    let BothPass (list: float list, fcut: float, order: int) = // return both filters at the same time
        let pass = LowPass (list, fcut, order)
        let bothPass = HighPass (pass, fcut, order)
        bothPass

    // Create a flange effect
    let flange (wave: float list)=

        let wave2 = [
            let mutable a = 1 // Numbers of value to be deleted
            let mutable i = 0 // Increment value
            let mutable leftRight = 0 // Bool to Remove more or less values
            while i < wave.Length-1 do
                
                // printfn "i= %O   /  mid = %O   /   a= %O" i mid a
                if i % 10 = 0 then // Check for every 10 values
                    if a = 10 then  // If the numbers of value to delete is at 10, invert the process to it goes back to 0
                        leftRight <- 1
                    elif a = 0 then // If the numbers of value to delete is at 0, invert the process to it goes back to 10
                        leftRight <- 0
                    
                    if leftRight = 0 then a <- a+1 // Watch if you have to remove more or less values
                    else a <- a-1

                    if a <0 then i <- i+1   // Security for a to never goes under 0
                    else i <- i+a           // Skip a number of values to return, so it change the frequency

                else 
                    i <- i+1        // increment anyways so it goes to the next value
                    yield wave.[i]   // Return the base value of the list
        ]
        
        let returnWave = [
            for i = 0 to wave2.Length-1 do
                yield ( (wave.[i]+ wave2.[i]) /2. )
        ]

        returnWave
        
        
        
        
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
        

    //This function will module the amplitude and the frequence of the wave
    let bothModulation (wave: list<float>) amp highFreq lowFreq =
        let N = float wave.Length
        let t = 1. + (1./44100.)
        let points = [(0.) .. t .. N+1.]
        
        // This is a mathematical formule to module the amplitude and the frequence of the wave
        let transform x =
            amp * 
            Math.Sin ( 2. * System.Math.PI * highFreq * x * highFreq * Math.Cos (2. * System.Math.PI * lowFreq * x))
        
        // put all points with there calculation into a new list
        let points = points |> List.map transform
        //we mutiply the initial list with the list with calculation
        let sumList = List.map2 (fun x y -> x * y) wave points
        sumList

    // This function will module the amplitude of the wave
    let amplitudeModulation (wave: list<float>) amp freq =
        let N = float wave.Length
        let t = 1. + (1./44100.)
        let points = [(0.) .. t .. N+1.]
        let omega = 2. * System.Math.PI * freq

        // This is a mathematical formule to module the amplitude of the wave
        let transform x =
            amp * (Math.Sin ( omega * x  ) * Math.Sin (omega * x))
        
        // put all points with there calculation into a new list
        let points = points |> List.map transform
        //we mutiply the initial list with the list with calculation
        let sumList = List.map2 (fun x y -> x * y) wave points
        sumList

        // This is a mathematical formule to module the frequence of the wave
    let transform highFreq lowFreq x =
        
        Math.Sin ( 2. * System.Math.PI * highFreq * x  * highFreq * Math.Cos (2. * System.Math.PI * lowFreq * x))


    // This function will module the frequency of the wave
    let frequencyModulation (wave: list<float>) highFreq lowFreq =
        let N = float wave.Length
        let t = 1. + (1./44100.)
        let points = [(0.) .. t .. N+1.]
        
        // put all points with there calculation into a new list
        let points = points |> List.map (transform highFreq lowFreq)
        //we mutiply the initial list with the list with calculation
        let sumList = List.map2 (fun x y -> (x + y)/2. ) wave points
        sumList
