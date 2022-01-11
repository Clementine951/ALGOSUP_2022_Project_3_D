namespace AudioSynth


open System
open SFML.Audio
open System.Threading

module playSynth = 
    let PlaySound (name:string) =
        let buffer = new SoundBuffer(name)
        let sound = new Sound(buffer)
        sound.Play()

        while sound.Status = SoundStatus.Playing do
            Thread.Sleep(100)

    // let play = PlaySound "test.wav"