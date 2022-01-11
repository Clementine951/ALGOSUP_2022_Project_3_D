namespace AudioSynth


open System
open SFML.Audio //Allow to use SFML library
open System.Threading

module playSynth = 
    let PlaySound (name:string) = //Allow to choose your file
        let buffer = new SoundBuffer(name) //Storage for audio sample defining a sound
        let sound = new Sound(buffer) //Allow to use the sound stored in SoundBuffer
        sound.Play() //Play the sound

        while sound.Status = SoundStatus.Playing do
            Thread.Sleep(100)

    let play = PlaySound "test.wav" //Play the file you choose