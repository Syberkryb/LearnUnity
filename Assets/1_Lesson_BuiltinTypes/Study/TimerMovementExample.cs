using UnityEngine;

//A very importent part of Unity, is the concept of the "Transform".
//The transform is a part of every gameobject in the scene, and by extension this script.
//It is inherited via the " : MonoBehaviour" as part of this Classes definition

//By calling the transform objects build in "SetPositionAndRotation" or "Translate" methods
//the transform can be repositioned/rotated/scaled
//If we use this relative to the in-game time, we can achieve movement and animation of any object!

//This script is an example of how movement can be achieved based on time via the transform object in the scene.
//You should have read and understood the BuiltinNumbersExample.cs before reading this file
//If you select a GameObject in the scene with this script attached, you can try enabling/disabling the booleans true/false values in the inspector.

public class TimerMovementExample : MonoBehaviour {
    
    public int IntTimer;
    public float FloatTimer;
    
    public bool TryMoveAlongX = false;
    public bool TryWithOscilatingPosition = false;
    public bool TryWithOscilatingPositionAndIntegerChangedTimer = false;

    //Unity's Overriden Start Method, which acts as a Parameter-less Constructor.
    //It have been overriden via the inheritance from "MonoBehaviour", see it at the top of the "Class" definition.
    public void Start()
    {
        IntTimer = 1;
        FloatTimer = 1.0f;
    }
 
    //Called every frame
    //Inherited via MonoBehaviour
    public void Update()
    {       
        /* Movement examples */

        //No timers needed for first movement example
        //It teleports the object along the x-axis, by "+1" every frame if TryMoveAlongX is true
        if(TryMoveAlongX){
            Vector3 calculateNewXValue = transform.position; //Creating a new Vector3 with the GameObjects current transform position
            calculateNewXValue.x = transform.position.x + 1; //Adds +1 in to the x-value
            transform.SetPositionAndRotation(calculateNewXValue, transform.rotation); //Sets the new position
        }

        //Second example only translates position if the integer timer have changed to a new number
        if(TryWithOscilatingPositionAndIntegerChangedTimer){
            if(IntTimer < (int)FloatTimer){ 
                transform.Translate(Vector3.up * Mathf.Cos(FloatTimer)*100);
            }
        }

        //Update timers        
        IntTimer = (int)FloatTimer; 
        FloatTimer += Time.deltaTime;

        //Third example uses a float timer as input to a cosinus function found in the UnityEngines Math library
        if(TryWithOscilatingPosition){
            //Translate moves an object in a direction based on a Vector3, (x,y,z)
            //If we multiply vector(0,1,0) and a cosinus function with "time" as input we achieve oscilation!
            transform.Translate(Vector3.up * Mathf.Cos(FloatTimer)); 
        }

        //If escape is pressed, set all booleans to false
        if(Input.GetKeyDown(KeyCode.Escape)){
            TryMoveAlongX = false;
            TryWithOscilatingPosition = false;
            TryWithOscilatingPositionAndIntegerChangedTimer = false;
        }
    }

}
