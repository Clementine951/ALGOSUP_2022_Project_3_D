namespace synthesizer

module Spectroscope = 
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
       
 