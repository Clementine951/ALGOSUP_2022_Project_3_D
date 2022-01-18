namespace synthesizer


open System
open System.Threading
open WaveGen

module NoteToHz = 
    let convert note octave = // Convert a Note as string into the frequency related
        let noteHz =
            match note with
            | "C" | "c" -> 16.35
            | "C#" | "c#" -> 17.32
            | "D" | "d" -> 18.35
            | "D#" | "d#" -> 19.45
            | "E" | "e" -> 20.60
            | "F" | "f" -> 21.83
            | "F#" | "f#" -> 23.12
            | "G" | "g" -> 24.5
            | "G#" | "g#" -> 25.96
            | "A" | "a" -> 27.5
            | "A#" | "a#" -> 29.14
            | "B" | "b" -> 30.87
            | _ -> 0.

        let result = noteHz * (2. ** octave) // Multiply the frequency by the octave
        let result = float (Math.Round result)
        result
    

    // Function to access easily more parts of a tuple, do the same as fst and snd
    let first (a, _, _, _) = a
    let second (_, b, _, _) = b
    let third (_, _, c, _) = c
    let fourth (_, _, _, d) = d


    //
    let noteListToFloatList (inputNote:(string * float * float * float)[]) (sampleRate:float) =
        let listNormalWave = [
            for i = 0 to inputNote.Length-1 do
                let tmp = WaveGen.calcSin sampleRate (fourth inputNote[i]) (convert (first inputNote[i]) (second inputNote[i])) (third inputNote[i])
                yield tmp
        ]
        let normalWave = List.concat listNormalWave
        normalWave
