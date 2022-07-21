using UnityEngine;

public class UnityBuiltinsExample : MonoBehaviour
{
    //As part of "using UnityEngine", we have to learn more about the extended suite of types
    public Vector3 SpawnPosition;
    public Transform MyTransform;
    
    //When the game starts, this method is the first to be called
    //If the script exists on an active GameObject in the Scene
    void Start()
    {
        MyTransform = transform; //They are now the same "object" reference and we can use them interchangeably
        SpawnPosition = transform.position; //Set the spawn position to the transforms current position
    }

    // Update is called once per frame
    void Update()
    {
        //Using Unitys builtin "Input" handler 
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left * 10); //Multiplying with 10 to increase effect of translation
        }
        if(Input.GetKey(KeyCode.D) == true){
            MyTransform.Translate(Vector3.right * 10); //Multiplying with 10 to increase effect of translation
        }


        //Manipulating size/scale of an object
        if(Input.GetKeyDown(KeyCode.W)){
            transform.localScale += new Vector3(0.1f, 0, 0); //Scale a little on the x axis in the positive direction
        }
        if(Input.GetKeyDown(KeyCode.S)){
            MyTransform.localScale += new Vector3(-0.1f, 0, 0); //Scale a little on the x axis in the negative direction
        }


        //If escape is pressed, reset position based on Vector3 SpawnPosition that was recorded in the Start()-method
        if(Input.GetKeyDown(KeyCode.Escape)){
            MyTransform.SetPositionAndRotation(SpawnPosition, Quaternion.identity); //"Quaternion.identity" means "no rotation"
        }
    }
}
