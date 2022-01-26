module wavesTest

open NUnit.Framework
open synthesizer.WaveGen


[<TestCase(44100   ,  1.   ,  131.  ,  0.8  )>]
[<TestCase(44100   ,  0.5  ,  600.  ,  0.9  )>]
[<TestCase(4410    ,  0.7  ,  1300. ,  1.   )>]

let sineTesting sampleRate time hz amp =

    let sineWave = calcSin sampleRate time hz amp   // Create a wave

    let expectedSamples = sampleRate * time         // Get the expected Samples numbers

    let resultSamples = sineWave.Length             // Get the actual numbers of samples
    let resultHighAmp = List.max sineWave           // Get the Highest point on the wave
    let resultLowAmp = List.min sineWave            // Get the Lowest point on the wave

    Assert.AreEqual( resultSamples, expectedSamples )   // Compare the sample rate with what we are supposed to have
    Assert.LessOrEqual ( resultHighAmp, amp)            // Compare if the Highest amplitude isn't higher that the set amplitude
    Assert.GreaterOrEqual ( resultLowAmp, (-amp))       // Compare if the lowest amplitude isn't lower than the set amplitude




[<TestCase(44100   ,  1.   ,  131.  ,  0.8  )>]
[<TestCase(44100   ,  0.5  ,  600.  ,  0.9  )>]
[<TestCase(4410    ,  0.7  ,  1300. ,  1.   )>]

let squareTesting sampleRate time hz amp =

    let squareWave = calcSquare sampleRate time hz amp   // Create a wave

    let expectedSamples = sampleRate * time         // Get the expected Samples numbers

    let resultSamples = squareWave.Length             // Get the actual numbers of samples
    let resultHighAmp = List.max squareWave           // Get the Highest point on the wave
    let resultLowAmp = List.min squareWave            // Get the Lowest point on the wave

    Assert.AreEqual( resultSamples, expectedSamples )   // Compare the sample rate with what we are supposed to have
    Assert.LessOrEqual ( resultHighAmp, amp)            // Compare if the Highest amplitude isn't higher that the set amplitude
    Assert.GreaterOrEqual ( resultLowAmp, (-amp))       // Compare if the lowest amplitude isn't lower than the set amplitude



[<TestCase(44100   ,  1.   ,  131.  ,  0.8  )>]
[<TestCase(44100   ,  0.5  ,  600.  ,  0.9  )>]
[<TestCase(4410    ,  0.7  ,  1300. ,  1.   )>]

let sawTesting sampleRate time hz amp =

    let sawWave = calcSaw sampleRate time hz amp   // Create a wave

    let expectedSamples = sampleRate * time         // Get the expected Samples numbers

    let resultSamples = sawWave.Length             // Get the actual numbers of samples
    let resultHighAmp = List.max sawWave           // Get the Highest point on the wave
    let resultLowAmp = List.min sawWave            // Get the Lowest point on the wave

    Assert.AreEqual( resultSamples, expectedSamples )   // Compare the sample rate with what we are supposed to have
    Assert.LessOrEqual ( resultHighAmp, amp)            // Compare if the Highest amplitude isn't higher that the set amplitude
    Assert.GreaterOrEqual ( resultLowAmp, (-amp))       // Compare if the lowest amplitude isn't lower than the set amplitude




[<TestCase(44100   ,  1.   ,  131.  ,  0.8  )>]
[<TestCase(44100   ,  0.5  ,  600.  ,  0.9  )>]
[<TestCase(4410    ,  0.7  ,  1300. ,  1.   )>]

let triTesting sampleRate time hz amp =

    let triWave = calcTri sampleRate time hz amp   // Create a wave

    let expectedSamples = sampleRate * time         // Get the expected Samples numbers

    let resultSamples = triWave.Length             // Get the actual numbers of samples
    let resultHighAmp = List.max triWave           // Get the Highest point on the wave
    let resultLowAmp = List.min triWave            // Get the Lowest point on the wave

    Assert.AreEqual( resultSamples, expectedSamples )   // Compare the sample rate with what we are supposed to have
    Assert.LessOrEqual ( resultHighAmp, amp)            // Compare if the Highest amplitude isn't higher that the set amplitude
    Assert.GreaterOrEqual ( resultLowAmp, (-amp))       // Compare if the lowest amplitude isn't lower than the set amplitude