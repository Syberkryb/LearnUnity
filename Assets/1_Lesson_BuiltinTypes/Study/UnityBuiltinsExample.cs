using UnityEngine;

public class UnityBuiltinsExample : MonoBehaviour
{
    //As part of "using UnityEngine", we have to learn more about the extended suite of types, such as;
    public Vector3 SpawnPosition; //(x,y,z)
    public Vector3 MoveToPosition; //(x,y,z)
    public Transform t; //Transforms are part of every gameobjects in the scene
    
    //When the game starts, this method is the first to be called
    //If the script exists on an active GameObject in the Scene
    void Start()
    {
        t = transform; //both "transform" and "t" are now referencing/pointing to the same object and can be used interchangeably.
        SpawnPosition = transform.position; //Set the spawn position to the transforms current position
    }

    
    void Update()
    {
        //Using Unitys builtin "Input" handler 
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.left * 10); //Multiplying with 10 to increase effect of translation
        }
        if(Input.GetKey(KeyCode.A) == true){
            t.Translate(Vector3.right * 10); //Multiplying with 10 to increase effect of translation
        }

        //Manipulating size/scale of an object
        if(Input.GetKeyDown(KeyCode.W)){
            transform.localScale += new Vector3(0.1f, 0, 0); //Scale a little on the x axis in the positive direction
        }
        if(Input.GetKeyDown(KeyCode.S)){
            t.localScale += new Vector3(-0.1f, 0, 0); //Scale a little on the x axis in the negative direction
        }

        //Try changing the "MoveToPosition" in the inspector and keeping space held down
        if(Input.GetKey(KeyCode.Space)){
            transform.position = Vector3.MoveTowards(transform.position, MoveToPosition, Time.deltaTime*100);
        }
        
        //If escape is pressed, reset position based on Vector3 SpawnPosition that was recorded in the Start()-method
        if(Input.GetKeyDown(KeyCode.Escape)){
            t.SetPositionAndRotation(SpawnPosition, Quaternion.identity); //"Quaternion.identity" means "no rotation"
        }

    }
}
