namespace synthesizer

open Plotly.NET

module Charts =

    let makeCharts (wave: list<float>) =
       wave 
       |> List.mapi (fun i x -> i,x) 
       |> List.take 500
       |> Chart.Line 
