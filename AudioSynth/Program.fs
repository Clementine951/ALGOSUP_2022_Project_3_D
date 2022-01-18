// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
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
        ("G", 3., 0.9, 0.9)
        ("G#", 3., 0.9, 0.9)
        ("G", 3., 0.9, 0.9)
        ("A", 3., 0.9, 0.9)
        ("B", 3., 0.9, 0.9)
        ("A", 3., 0.9, 0.9)
        ("G", 3., 0.9, 0.9)
        ("B", 3., 0.9, 0.9)
        ("A", 3., 0.9, 0.9)
        ("C", 3., 0.9, 0.9)
        ("G", 3., 0.9, 0.9)
    |]
//                                    List of notes  Samplerate
    let normalWave = noteListToFloatList inputNote 44100.

    // let normalWave = calcSin 44100. 1. 130.9 0.9

    // let test = NoteToHz.convert "A" 6
    //let normalWave = Filter.sinFlange 44100. 10. 40000.  1.

    /// Write WAVE PCM soundfile (8KHz Mono 8-bit)
    let stream = File.Create(@"test.wav")
    save.write stream normalWave



    PlaySynth.playSound ("test.wav" ,true ,float32(0.))
     // return an integer exit code
