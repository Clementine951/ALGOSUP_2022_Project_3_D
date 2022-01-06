// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// y sin (g X )
// y = amplitude height of the function
// g = Multiplier of Period
// Period = g x 2 pi

open System

// Define a function to construct a message to print
let calcSin y m a = // Y = prescision, a = amplitude, m = period multiplier
    // a sin ( m x ) 
    let pointsList = new System.Collections.Generic.List<'T>()
    //let m = float(m)
    let pointsNumbers = (m / y)

    let pointsNumbers =  int (pointsNumbers)

    let m = int(m)
    // let y = (float y)
    // let m = (float m)
    // let a = (float a)

    
    for i = 0 to ((314/2) * m) do
        let pointsNumbers = (float pointsNumbers)
        let m = float(m)
        let i = (float i)

        let xCoord = (i * (2.*y)) /pointsNumbers
        // printfn "X : %O" xCoord

        let yCoord =  a * sin (m * xCoord)
        // printfn "Y : %O" yCoord

        let point = (xCoord , yCoord)
        pointsList.Add(point) 
        pointsList
    pointsList

let calcSquare y m a = // Y = prescision, a = amplitude, m = period multiplier
    // a sin ( m x ) 

    let pointsList = calcSin y m a
    for i in pointsList do
        let y = snd(i)

        let result =
            if y > 0 then a
            else -a

        let snd(i) = result
        pointsList
    pointsList
        //printfn "%O" i

    pointsList
    

[<EntryPoint>]
let main argv =
    let normalWave = calcSin 0.1 2. 2.

    let squareWave = calcSquare 0.1 2. 2.
    //printfn "%A" normalWave
    0 // return an integer exit code