using UnityEngine;

/*
 *  C# Complete list of builtin data types, where you can find a sometimes overwhelming amount of information, but try exploring.
 *  https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types
*/

public class TimerMovementExample : MonoBehaviour {
    
    public int IntTimer;
    public float FloatTimer;
    public double DoubleTimer;
    public bool MoveAlongX = false;
    public bool TryWithOscilatingPosition = false;
    public bool TryWithOscilatingPositionAndIntegerChangedTimer = false;

    //Unity's Overriden Start Method, which acts as a Parameter-less Constructor.
    //It have been overriden via the inheritance from "MonoBehaviour", see it at the top of the "Class" definition.
    public void Start()
    {
        IntTimer = 1;
        FloatTimer = 1.0f;
        DoubleTimer = 1.00000;
    }
 
    public void Update()
    {
        //A very importent part of Unity, is the concept of the "Transform".
        //The transform is a part of every gameobject in the scene, and by extension this script.
        //It is inherited via the " : MonoBehaviour" as part of this Classes definition in some of the first lines
        
        //By calling the transform objects build in "SetPositionAndRotation" or "Translate" methods
        //the transform can be repositioned/rotated/scaled
        //If we use this relative to the in-game time, we can achieve movement and animation of any object!
        
        /* Update timers every frame with the added delta time */
        //Notice the "+=" which translates to " FloatTimer = FloatTimer + Time.deltaTime "
        FloatTimer += Time.deltaTime;
        DoubleTimer += Time.deltaTime;

        /* Movement examples */
        //No timers needed for first movement example
        //It teleports the object along the x-axis, by "1" every frame
        if(MoveAlongX){
            Vector3 calculateNewXValue = transform.position; //Creating a new Vector3 with the GameObjects current transform position
            calculateNewXValue.x = transform.position.x + 1; //Adds +1 in to the x-value
            transform.SetPositionAndRotation(calculateNewXValue, transform.rotation); //Sets the new position
        }
        
        //Second example uses a float timer as input to a cosinus function found in the UnityEngines Math library
        if(TryWithOscilatingPosition){
            //Translate moves an object in a direction based on a Vector3, (x,y,z)
            //If we multiply vector(0,1,0) and a cosinus function with "time" as input we achieve oscilation!
            transform.Translate(Vector3.up * Mathf.Cos(FloatTimer)); 
        }


        if(TryWithOscilatingPositionAndIntegerChangedTimer){
            if(IntTimer != (int)FloatTimer){ //Check if Integer timer have changed to a new number
                transform.Translate(Vector3.up * Mathf.Cos(FloatTimer)*100);
            }
        }

        //As the builtin "Time.deltaTime" is a float value, some "casting" is needed
        IntTimer = (int)FloatTimer; //Can you spot why the int timer is in the bottom and not updated together with the other 2 timers?

        //If escape is pressed, set all booleans to false
        if(Input.GetKeyDown(KeyCode.Escape)){
            MoveAlongX = false;
            TryWithOscilatingPosition = false;
            TryWithOscilatingPositionAndIntegerChangedTimer = false;
        }
    }
}
