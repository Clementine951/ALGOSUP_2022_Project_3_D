//namespace test
module SynthAudioTest

open NUnit.Framework
open synthesizer.WaveGen

[<SetUp>]
let Setup () =
    ()

[<Test>]
let AreWavesListNotEmpty () =
    let sin= calcSin 44100. 2. 440. 0.8
    let saw= calcSaw 44100. 2. 440. 0.8
    let square= calcSquare 44100. 2. 440. 0.8
    let triangle= calcTri 44100. 2. 440. 0.8

    Assert.IsNotEmpty(sin)
    Assert.IsNotEmpty(saw)
    Assert.IsNotEmpty(square)
    Assert.IsNotEmpty(triangle)
