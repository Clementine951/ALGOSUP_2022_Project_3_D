//namespace test
module noteToHzTest

open NUnit.Framework
open synthesizer.WaveGen
open synthesizer.NoteToHz

[<SetUp>]
let Setup () =
    ()

[<TestCase("C",3.,131.)>]
[<TestCase("c",3.,131.)>]
[<TestCase("D#",6.,1245.)>]
[<TestCase("U",6.,0.)>]
    let testCaseTest(note:string, octave:float, expected:float) =
        let result = convert note octave
        Assert.AreEqual( result, expected )