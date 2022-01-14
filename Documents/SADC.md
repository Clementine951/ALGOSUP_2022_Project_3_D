# Software Architecture Design Choices

We choose to build our project like a library.
This library going to be used by calling our function to do what you want.
Every function is in f#.

The ALGOSUP_2022_Project_3_D project has two big folders:

- AudioSynth where all the functions are stocks.
- AudioSynthTest where all the tests are stocks.

In this document, we will focus on the AudioSynth folder. 

We decided to separate our functions into different modules depending on what they do. Each module is in different files.

## WaveGen module

The first is the WaveGen module. It is in the WaveForms.fs file. In this module, you can find four functions that create a waveform. 

The first one is `calcSin` for the calculation of a sin wave.
The second one is `calcSquare` for the calculation of a square wave.
The third one is `calcTri` for the calculation of a triangle wave.
The fourth one is `calcSaw` for the calculation of a sawtooth wave.

These four functions need four parameters:

    let calcSin sampleRate time freq amp =

The "sampleRate" parameter is to define how many bytes you want in the wave file. The "time" parameter is for how long you want your wave. The "freq" parameter is to define the frequency of the wave and the "amp" parameter defines the amplitude of your wave.  

These four functions make a mathematical calculation to have x points, follow the duration, and with these all points, it builds an array of bytes.

Afterward, if you want to play or save this sound, you must use the PlaySynth or the SaveSynth module.


## SaveSynth module

The SaveSynth module is in the Save.fs file. In this module, you will find three functions:

- Save -> This function helps you to save a waveform in a wav file.
- SaveMP -> This function will save a waveform in an mp3 file.
- (**Delete -> With this function, you may delete a file that you want.**)

**Add more precisions.** 


## PlaySynth module

In the PlaySynth module, you will find four functions. This module is in the Play.fs file.

The PlaySound function will play a .wav file that is already saved.
To use this function, you just have to give the name of the file you want to play.

The Play function is to play a sound without a saved file. 
For this function, you just need to give the name of the variable with the array of bytes.

The PlayFrom function plays a .wav file from a given moment.
The two parameters for this function are the name of a .wav file and when you want to start the sound.

Then you have the PlayMult function with three parameters. This function 
For the first parameter, you have to give the name of the file that you want to play (with the extension).
The second parameter is if you want to delete or keep your file. If you put true, it going to keep your file and false if you want to delete it.
The last parameter is when you want to start the sound.

