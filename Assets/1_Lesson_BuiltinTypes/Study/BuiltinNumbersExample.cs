using UnityEngine;

public class BuiltinNumbersExample : MonoBehaviour
{
    /* Defining a whole number */
    //integer with keyword 'int' is a very common whole-number type across many languages
    //It has a range from -2,147,483,648 to 2,147,483,647 due its size: 32 bit or 4 bytes
    public int MyLuckyNumber = 7;
    public int HighestIntValue = int.MaxValue;
    public int LowestIntValue = int.MinValue;
    public int SizeOfAnIntegerInBytes = sizeof(int);

    
    /* Definining a floating number */
    //Floating point numbers in C# include "double", "float" and "decimal"
    //The most commonly used is float, due to its charecterics:
    //It has a range from ±1.5 x 10^−45 to ±3.4 x 10^38, which translates to ~6-9 digits, with a size of 32 bit or 4 bytes
    //Which further translates to: its usually accurate enough and it has a low memory "footprint", but beware off its imprecision.
    public float MyLuckyFloat = 1.0f/3.0f; //Notice the 'f' at the end of the numbers
    public float HighestFloatValue = float.MaxValue;
    public float LowestFloatValue = float.MinValue;
    public int SizeOfAFloatInBytes = sizeof(float);

    public double MyLuckyDouble = 12.345678910111213;
    public double HighestDouble = double.MaxValue;
    public double LowestDouble = double.MinValue;
    public int SizeOfADoubleInBytes = sizeof(double);
    
    //See these fields change in the inspector while the game is running
    public int IntTimer = 0;
    public float FloatTimer = 0;
    public double DoubleTimer = 0;

    //Update is called every frame
    //By adding up the time between frames, "deltaTime", we can create an ever increasing timer
    //Try playing the Scene and watch the timers go
    public void Update(){
        //Notice the "+=" which translates to "FloatTimer = FloatTimer + Time.deltaTime"
        FloatTimer += Time.deltaTime;
        DoubleTimer += Time.deltaTime;
        
        //As time between frames usually is less than 0.5f seconds, an integer timer cant be increased the same way
        //But we can just "Cast" the FloatTimer to an integer value
        IntTimer = (int)FloatTimer;
    }
}


/* Reference documents */
//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types