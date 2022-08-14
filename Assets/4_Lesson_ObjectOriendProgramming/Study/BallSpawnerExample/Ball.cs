using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody RigidbodyReference;
     
    void Awake()
    {
        RigidbodyReference = GetComponent<Rigidbody>();    
    }

    public void RandomColor(){
         Color randomColor = new Color(
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f)
        );
        GetComponent<Renderer>().material.color = randomColor;
    }

    public void Kick(float force){
        Vector3 ForceDirection = new Vector3(UnityEngine.Random.Range(-2.5f, 2.5f) ,UnityEngine.Random.Range(1f, 5f),UnityEngine.Random.Range(-2.5f, 2.5f));
        RigidbodyReference.AddForce(ForceDirection*force, ForceMode.Impulse);
    }

    public void Jump(float force){
        Vector3 ForceDirection = new Vector3(0f,1f,0f);
        RigidbodyReference.AddForce(ForceDirection*force);
    }
}
