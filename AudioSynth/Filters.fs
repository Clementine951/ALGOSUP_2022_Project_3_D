namespace synthesizer


open System
open System.IO
open SFML.Audio //Allow to use SFML library
open System.Threading
open SFML.System

module Filter =
    let waveModify  =
        let a = 1+1
        a