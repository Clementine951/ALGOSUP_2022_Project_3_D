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
    let pointsNumbers = m / y

    let y = (float y)
    let m = (float m)
    let a = (float a)

    
    for i = 0 to pointsNumbers do
        let pointsNumbers = (float pointsNumbers)
        let i = (float i)
        let xCoord = i * (pointsNumbers /(2./y))
        let yCoord =  a * sin m * i
        let point = (xCoord , yCoord)
        pointsList.Add(point) 
        pointsList
    pointsList
    

[<EntryPoint>]
let main argv =
    let test = calcSin 1 2 2
    printfn "%A" test
    0 // return an integer exit code