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
    
    

    let Overdriven (points:float list,a:float, t:float,N:float,freq:float,omega:float, trig:int) =
    

        let ampList = [(0.)..t..N]

       let ampList1 = ampList |> List.map(fun x -> a * sin(omega*x) )
       let ampList2 = ampList |> List.map(fun x -> a * float (sign (sin (x * omega))) )
       let ampList3 = ampList |> List.map(fun x ->  a * 2. * asin (sin (x*omega)) / System.Math.PI )
       let ampList4 = ampList |> List.map(fun x ->  a * 2. * (x * freq - floor (0.5 +  x * freq)) )
       let ampList5 = ampList |>  List.map(fun x -> a * sin(omega*x*10.005) )


    
    
        let lenght = points.Length
        let check1 =[for i in 0..lenght-1 do if points.[i]>= ampList1.[i] then ampList1.[i] else points.[i]]
        let check2 =[for i in 0..lenght-1 do if points.[i]>= ampList2.[i] then ampList2.[i] else points.[i]]
        let check3 =[for i in 0..lenght-1 do if points.[i]>= ampList3.[i] then ampList3.[i] else points.[i]]
        let check4 =[for i in 0..lenght-1 do if points.[i]>= ampList4.[i] then ampList4.[i] else points.[i]]
        let check5 =[for i in 0..lenght-1 do if points.[i]>= ampList5.[i] then ampList5.[i] else points.[i]]
    
        if trig = 1 then
            check1
            (*printfn"check1 %A" check1.[0..5]*)
        
        elif trig = 2 then
            check2
            (*printfn"check2 %A" check2.[0..5]*)
            
            
        elif trig = 3 then
            check3
            (*printfn"check3 %A" check3.[0..5]*)
        elif trig = 4 then
            check4
            
        else
            check5
            (*printfn"check4 %A" check4.[0..5]*)


    // let flange wave (t:float, N:float)=

    //     let subWave = [(0.)..t..N]
    
    //     let subWave = subWave |> List.map(fun x -> wave * -1.)
    //     subWave