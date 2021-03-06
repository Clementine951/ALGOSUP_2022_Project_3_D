namespace synthesizer


open System
open System.IO
open SFML.Audio //Allow to use SFML library
open System.Threading
open SFML.System

module PlaySynth = 
    let playSound (name:string,save:bool,time:float32) = //Allow to choose your file and time of section do you want to read
        let buffer = new SoundBuffer(name) //Storage for audio sample defining a sound
        let sound = new Sound(buffer) //Allow to use the sound stored in SoundBuffer
        let times = Time.FromSeconds(time) // Set up time of file section
        sound.set_PlayingOffset(times)// Read the section of file 
        sound.Play() //Play the sound

        while sound.Status = SoundStatus.Playing do
            Thread.Sleep(100)


        if (save=false) then System.IO.File.Delete(name) //Save, play and delete the sound

    // let play = playSound "test.wav" //Play the file you choose
