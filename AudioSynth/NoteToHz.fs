namespace synthesizer


open System
open System.Threading

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
        result
