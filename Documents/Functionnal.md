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
  - [A. Low-Pass Filter](#a-low-pass-filter)
  - [B. High-Pass Filter](#b-high-pass-filter)
  - [C. low Frequency Oscillator](#c-low-frequency-oscillator)
  - [D. Envellope](#d-envellope)
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

As it should be able to be used in another program, it should be an API, a Librairy or a Package.&nbsp;
It should have basic functions to generate sound based on differents options, like possibility to use note or pur frequency to generate a sound.

&nbsp;

## C. Compatibility Cross-platform

The program have to be available and usable on MacOS and Windows.

&nbsp;



# 2. Definitions of terms
## A. Waves

Any sounds correspond to a wave. A wave that make fluid (Mainly Air for sound) vibrate and produce earable sound.
It exist 4 type of waves, Sine, Square, Triangle, Sawtooth. &nbsp;
Each wave produce a different type of sound.

For all waves, a few technicals terms come along: 
  - Frequency = The pitch of a sound
  - Period = Time needed to reproduce the same pattern in a wave
  - Fundamental = Main note of a sound, a Sine is special as it's only the fundamental note
  - Harmonics = Fundamental or main pitch or note, plus they have higher pitches that are voiced above the fundamental.

### a. Sine wave

![Sine wave](https://www.thedawstudio.com/wp-content/uploads/2016/08/Sine-Wave_1000-300x195.jpg)


The most basic and simple waveform, a sine wave has a simple hollow sound. It does not exist in nature, but is the simplest sound to reproduce with electronics.

The sine wave have a well know formula: &nbsp;
  **y(x)=A * sin(2π * f)** &nbsp;
  Where A = amplitude of the sound, How high the curve will go &nbsp;
  Where f = Frequency of the sound, How high the sound will be &nbsp;
  Where 2π = Constant for the Period, modified directly because of the frequency &nbsp;

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

A triangle wave have the property of a sine wave and a square wave combined. &nbsp;
It still a little bit buzzy because of the square wave property, and at the same time still clear and constant sound because of sine properties

&nbsp;
&nbsp;


## B. Basic Filters
### a. Amplitude modification
### b. Overdriven
### c. Echo
### d. Reverb
### e. Flange

## C. Advanced Filters

## A. Low-Pass Filter
## B. High-Pass Filter
## C. low Frequency Oscillator

## D. Envellope
### a. Attack
### b. Decay
### c. Sustain
### d. Release


# 3. Users

## A. Who
## B. Why


# 4. Userflow

## A. How to use it

## B. Generic Code example
### a. Generate a simple note
### b. Apply an echo to the previous note
### c. Remove low frequency from a sound


# 5. Out of Scope

## A. Interface
## B. Android Compatibility
## C. IOS Compatibility
## D. Keyboard in interface to play as a Piano


