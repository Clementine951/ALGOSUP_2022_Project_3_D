module filterTest

open NUnit.Framework
open synthesizer.Filters

[<Test>]

let amplitudeTest =             // Seems like Test case doesn't support premade list as parameters so i decided to do another way

    let list1 = [1.; 0.5; 0.2; 0.1]         // Create my Inputs as List of Float    
    let list2 = [1. ; 10. ; 100. ; 1000.]

    let expectedResult1 = 0.5               // Define my expected results
    let expectedResult2 = 300.
//=========================================================
//=========================================================
    let result1 = List.max (amplitude list1 0.5)
    let result2 = List.max (amplitude list2 0.3)

    Assert.AreEqual( result1, expectedResult1 )   // Watch if the filter amplitude have been applied
    Assert.AreEqual( result2, expectedResult2 )   

[<Test>]

let overdrivenTest =             // Seems like Test case doesn't support premade list as parameters so i decided to do another way

    let list1 = [1.; 0.5; 0.2; 0.1]         // Create my Inputs as List of Float    
    let list2 = [1. ; 10. ; 100. ; 1000.]

    let expectedResult1 = 0.8               // Define my expected results
    let expectedResult2 = 25.
//=========================================================
//=========================================================
    let result1 = List.max (Overdriven list1 0.8)
    let result2 = List.max (Overdriven list2 25.)

    Assert.AreEqual( result1, expectedResult1 )   // Watch if the filter amplitude have been applied
    Assert.AreEqual( result2, expectedResult2 )   
