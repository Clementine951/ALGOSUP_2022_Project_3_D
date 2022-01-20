// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

// y sin (g X )
// y = amplitude height of the function
// g = Multiplier of Period
// Period = g x 2 pi

namespace synthesizer

open System
open System.IO
open System.Threading

open WaveGen
open PlaySynth
open NoteToHz

module Main =

    let inputNote = [|
        // ( "NOTE":string, OCTAVE:float, AMPLITUDE:float PLAYTIME:float,)
        ("G", 4., 0.8, 2.)
      //   ("G#", 3., 0.8, 2.)
        // ("G", 3., 0.5, 1.)
        // ("A", 3., 0.9, 0.9)
        // ("B", 3., 0.9, 0.9)
        // ("A", 3., 0.9, 0.9)
        // ("G", 3., 0.9, 0.9)
        // ("B", 3., 0.9, 0.9)
        // ("A", 3., 0.9, 0.9)
        // ("C", 3., 0.9, 0.9)
        // ("G", 3., 0.9, 0.9)
    |]
//                                    List of notes  Samplerate
    let normalWave2 = noteListToFloatList inputNote 44100.

    let normalWave = Filter.echo normalWave2 2.05 0.5 1.



    // let normalWave = calcSin 44100. 1. 130.9 0.9

    // let test = NoteToHz.convert "A" 6
    //let normalWave = Filter.sinFlange 44100. 10. 40000.  1.

    /// Write WAVE PCM soundfile (8KHz Mono 8-bit)
    let stream = File.Create(@"test.wav")
    save.write stream normalWave



    PlaySynth.playSound ("test.wav" ,true ,float32(0.))
     // return an integer exit code
