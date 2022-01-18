
# Functionnal Specification

## Goals

For this project we have to create a programmable synthesizer in F#, it is basically an electronic musical instrument that generates audio signals. With our programmable synthesizer, the user will be able to create sounds by generating waveforms from f# code.

Deadline: 11 of February 2022

  - We have created this application following the request of Robert Pickering.
  - All the code will be accessible on GitHub.

  The project is developed with F#.

  

## Deliverables

| Ref | Description                                                                                   | Required By Date |
| --- | --------------------------------------------------------------------------------------------- | ---------------- |
| 1   | Function specification                                                                        | 20 January 2022  |
| 2   | Technical specification                                                                       | 20 January 2022  |
| 3   | Software architecture design choices                                                          | 20 January 2022  |
| 4   | Project execution plan                                                                        | 20 January 2022  |
| 5   | Unit tests that will automatically show that the logic implemented by the API works correctly | 11 February 2022 |


## Tasks


| Ref | Description                                                                                         | Required By Date | Dependency |
| --- | --------------------------------------------------------------------------------------------------- | ---------------- | ---------- |
| 1   | The four basic wave forms are sine, square, triangle and sawtooth.                                  | 14 January 2022  | /          |
| 2   | A function to save waveform to disk, so it can be played back through a standard audio application. | 14 January 2022  | 1          |
| 3   | A function to read a section of an audio file from disk.                                            | 14 January 2022  | 2          |
| 4   | A function to play the waveform directly without saving it to disk.                                 | 14 January 2022  | 3          |
| 5   | Modify the wave’s amplitude by a fixed amount                                                       | 21 January 2022  | 4          |
| 6   | Cut off the wave at specific amplitude to given the “overdriven” often used in rock songs           | 21 January 2022  | 5          |
| 7   | Add echo to the sound                                                                               | 21 January 2022  | 6          |
| 8   | A flange effect filter                                                                              | 21 January 2022  | 7          |
| 9   | A reverb effect filter                                                                              | 21 January 2022  | 8          |
| 10  | Frequency Analysis and Advanced filters                                                             | 28 January 2022  | 9          |
| 11  | MP3 Compression                                                                                     | 11 February 2022 | 10         |



## Risks and assumptions 

| Ref | Description        | Likelihood | Impact                             | Mitigation Strategy                                                    |
| --- | ------------------ | ---------- | ---------------------------------- | ---------------------------------------------------------------------- |
| 1   | Delay              | 25%        | Delay on the other parts.          | More work at home, ask some advices to other teams or Robert Pickering |
| 2   | Technology risk    | 30%        | Restart the project, waste of time | More search.                                                           |
| 3   | Communication risk | 5%         | Bad atmosphere, no productivity    | More meeting, motivation, encouragement                                |


## Requirements 

To run this project you will need an IDE, we have chosen to use [Visual Studio Code](https://code.visualstudio.com/download). 
You should also install [dotnet](https://dotnet.microsoft.com/en-us/download)

Once you have cloned our [project](https://github.com/Clementine951/ALGOSUP_2022_Project_3_D) and opened it in the IDE of your choice (we used Visual Studio Code), open the terminal and enter the following commands:

``` cd AudioSynth```

This command puts you in the file AudioSynth.

Then type this command to run the project :

``` dotnet run```

This command runs our project.


If you want just run our test you can type the ``` dotnet test``` command.

## Product overview 
-- the explanation of how the application will solve a specific problem for the target audience.
-- the functional requirements are placed in the context of a user action. This shows what happens from the user's perspective.

With our sound synthesizer, the user will be able to create a song with code and save his song, add some filters or echo. We will also offer conversion to the MP3 format.

## Non-functional requirements 

It would be possible to create an application or a user interface where users could create or modify their sound with buttons.

## Error reporting 
This program will have Unit Tests to avoid errors or exceptions. 
