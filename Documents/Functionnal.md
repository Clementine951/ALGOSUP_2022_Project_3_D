---

  

Table of Contents

  

- [1. Introduction](#1-introduction)

	- [A. Project description](#a-project-description)

	- [B. How it should be](#b-how-it-should-be)

	- [C. Compatibility Cross-platform](#c-compatibility-cross-platform)

- [2. Definitions of terms](#2-definitions-of-terms)

	- [A. Waves](#a-waves)

		- [a. Sine wave](#a-sine-wave)

		- [b. Square wave](#b-square-wave)

		- [c. Sawtooth wave](#c-sawtooth-wave)

		- [d. Triangle wave](#d-triangle-wave)

	- [B. Basic Filters](#b-basic-filters)

		- [a. Amplitude modification](#a-amplitude-modification)

		- [b. Overdriven](#b-overdriven)

		- [c. Echo](#c-echo)

		- [d. Reverb](#d-reverb)

		- [e. Flange](#e-flange)

	- [C. Advanced Filters](#c-advanced-filters)

		- [a. Low-Pass Filter](#a-low-pass-filter)

		- [b. High-Pass Filter](#b-high-pass-filter)

		- [c. low Frequency Oscillator](#c-low-frequency-oscillator)

	- [D. Envellope](#g-envellope)

		- [a. Attack](#a-attack)

		- [b. Decay](#b-decay)

		- [c. Sustain](#c-sustain)

		- [d. Release](#d-release)

- [3. Users](#3-users)

	- [A. Who](#a-who)

	- [B. Why](#b-why)

- [4. Userflow](#4-userflow)

	- [A. How to use it](#a-how-to-use-it)

	- [B. Generic Code example](#b-generic-code-example)

		- [a. Generate a simple note](#a-generate-a-simple-note)

		- [b. Apply an echo to the previous note](#b-apply-an-echo-to-the-previous-note)

		- [c. Remove low frequency from a sound](#c-remove-low-frequency-from-a-sound)

- [5. Out of Scope](#5-out-of-scope)

	- [A. Interface](#a-interface)

	- [B. Android Compatibility](#b-android-compatibility)

	- [C. IOS Compatibility](#c-ios-compatibility)

	- [D. Keyboard in interface to play as a Piano](#d-keyboard-in-interface-to-play-as-a-piano)

  
  
  
  

---

  

# 1. Introduction

  

## A. Project description

  

The aim of this project is to create a sound synthesizer that can be used to create

programmable music. This project was inspired by [Sonic Pi](https://sonic-pi.net/) and other live

coding music packages. The ultimate aim of this project is to be able to play music from code.

  

&nbsp;

  

## B. How it should be

  

As it should be able to be used in another program, it should be an API, a Librairy or a Package.

  

It should have basic functions to generate sound based on differents options, like possibility to use note or pur frequency to generate a sound.

  

&nbsp;

  

## C. Compatibility Cross-platform

  

The program have to be available and usable on MacOS and Windows.

  

&nbsp;

  
  
  

# 2. Definitions of terms

## A. Waves

  

Any sounds correspond to a wave. A wave that make fluid (Mainly Air for sound) vibrate and produce earable sound.

It exist 4 type of waves, Sine, Square, Triangle, Sawtooth.

  

Each wave produce a different type of sound.

  

For all waves, a few technicals terms come along:

- Frequency = The pitch of a sound

- Period = Time needed to reproduce the same pattern in a wave

- Fundamental = Main note of a sound, a Sine is special as it's only the fundamental note

- Harmonics = Fundamental or main pitch or note, plus they have higher pitches that are voiced above the fundamental.

  

### a. Sine wave

  

![Sine wave](https://www.thedawstudio.com/wp-content/uploads/2016/08/Sine-Wave_1000-300x195.jpg)

  
  

The most basic and simple waveform, a sine wave has a simple hollow sound. It does not exist in nature, but is the simplest sound to reproduce with electronics.

  

The sine wave have a well know formula:

  

`y(x)=A * sin(2π * f)`

  

- Where A = amplitude of the sound, How high the curve will go

- Where f = Frequency of the sound, How high the sound will be

- Where 2π = Constant for the Period, modified directly because of the frequency

  

&nbsp;

&nbsp;

  

### b. Square wave

  

![Square Wave](https://www.thedawstudio.com/wp-content/uploads/2016/08/Square-Wave_1000-300x195.jpg)

  

The square wave has only odd harmonics. This harmonic structure gives the square wave a little more bite to the sound. It kind of has a buzzing sound, but is not as intense as the sawtooth.

  

&nbsp;

&nbsp;

  

### c. Sawtooth wave

  

![Sawtooth wave](https://www.thedawstudio.com/wp-content/uploads/2016/08/Sawtooth-Wave_1000-300x195.jpg)

  

The sawtooth produces a lot of harmonic content and therefore a full buzzing sound. Notice how the wave looks like the teeth of a saw, hence the name.

  

### d. Triangle wave

  

![Triangle Wave](https://www.thedawstudio.com/wp-content/uploads/2016/08/Triangle-Wave_1000-300x195.jpg)

  

A triangle wave have the property of a sine wave and a square wave combined.

It still a little bit buzzy because of the square wave property, and at the same time still clear and constant sound because of sine properties

  

&nbsp;

&nbsp;

  
  

## B. Basic Filters

### a. Amplitude modification

The amplitude of a wave is the high of the curve will be.

<img src="images/amp.png" alt="amplitude" height="200"/>

The modification of the wave's amplitude will modify the power of the sound.
On the image below the blue wave has an amplitude of 1 and the red one has an amplitude of 0,5.

<img src="images/modifyamp.png" alt="Amplitude modification" height="200"/>

### b. Overdriven

The overdriven effect is to cut off the wave at specific amplitude.

<img src="images/overdriven.jpeg" alt="overdriven wave" height="200"/>

### c. Echo

The echo effect return the same wave with a different amplitude and with a delay that the user will choose.

<img src="images/echo.png" alt="echo wave" height="100"/>


### d. Reverb

The reverb effect will be applied to a sound to simulate reverberation. 

<img src="images/reverb.png" alt="Reverb wave" height="200"/>

Reverberation is a persistence of sound, or echo after a sound is produced.

<img src="images/reverb2.png" alt="Reverb look" height="200"/>



### e. Flange

Flanging is an audio effect produced by mixing two identical signals together, one signal delayed by a small and gradually changing period, usually smaller than 20 milliseconds.
The user will can choose the delay.


## C. Advanced Filters


### a. Low-Pass Filter

### b. High-Pass Filter

### c. low Frequency Oscillator

  

## D. Envellope

### a. Attack

### b. Decay

### c. Sustain

### d. Release

  
  

# 3. Users

  

## A. Who

  

The program will be designed to be used by devellopers or Sound artist with some knowledge of code.

  

&nbsp;

## B. Why

  

It's a librairy / API so a basic fan of sound won't be able to use that.

You will need to first learn coding before being able to use this program.

It doesn't have have UI so it won't be casual user friendly.

  
  

# 4. Userflow

  

## A. How to use it

  

You should be able a create a sound using Notes

  

## B. Generic Code example

### a. Generate a simple note

### b. Apply an echo to the previous note

### c. Remove low frequency from a sound

  
  

# 5. Out of Scope

  

## A. Interface

## B. Android Compatibility

## C. IOS Compatibility

## D. Keyboard in interface to play as a Piano