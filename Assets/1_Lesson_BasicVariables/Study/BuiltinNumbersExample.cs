using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Reference documents */
//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types

public class BuiltinNumbersExample : MonoBehaviour
{
    //Defining a whole number, an integer with keyword 'int'
    //Its a very common number type across many languages
    //It has a range from -2,147,483,648 to 2,147,483,647 due its size: 32 bit or 4 bytes
    public int HighestIntValue = int.MaxValue;
    public int LowestIntValue = int.MinValue;
    public int MyLuckyNumber = 7;
    public int SizeOfAnIntegerInBytes = sizeof(int);

    
    //Definining a floating number 
    //Floating point numbers in C# include "double", "float" and "decimal"
    //The most commonly used is float, due to its charecterics:
    //It has a range from ±1.5 x 10^−45 to ±3.4 x 10^38, which translates to ~6-9 digits, with a size of 32 bit or 4 bytes
    //Which further translates to: its usually accurate enough and it has a low memory "footprint", but beware off its imprecision.
    public float HighestFloatValue = float.MaxValue;
    public float LowestFloatValue = float.MinValue;
    public float MyLuckyFloat = 1.0f/3.0f; //Notice the 'f' at the end of the numbers

    public double HighestDouble = double.MaxValue;
    public double LowestDouble = double.MinValue;
    public double MyLuckyDouble = 12.345678910111213;

}
