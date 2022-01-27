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
    - [c. Triangle wave](#c-triangle-wave)
    - [d. Sawtooth wave](#d-sawtooth-wave)
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

&nbsp

## B. How it should be

As it should be able to be used in another program, it should be an API, a Librairy or a Package.
It should have basic functions to generate sound based on differents options, like possibility to use note or pur frequency to generate a sound.

&nbsp

## C. Compatibility Cross-platform

The program have to be available and usable on MacOS and Windows.

&nbsp



# 2. Definitions of terms
## A. Waves

Any sounds correspond to a wave. A wave that make fluid (Mainly Air for sound) vibrate and produce earable sound.
It exist 4 type of waves, Sine, Square, Triangle, Sawtooth.
Each wave produce a different type of sound.

### a. Sine wave

![Sine wave](https://www.thedawstudio.com/wp-content/uploads/2016/08/Sine-Wave_1000-300x195.jpg)
500 MHz Wave sound
![Sound player](https://www.thedawstudio.com/wp-content/uploads/2016/05/Sine_Wave-500hz.mp3)

### b. Square wave
### c. Triangle wave
### d. Sawtooth wave

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


