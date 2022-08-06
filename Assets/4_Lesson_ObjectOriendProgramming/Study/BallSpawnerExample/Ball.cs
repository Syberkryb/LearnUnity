using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody RigidbodyReference;
     
    void Awake()
    {
        RigidbodyReference = GetComponent<Rigidbody>();    
    }

    public void Kick(float force){
        Vector3 ForceDirection = new Vector3(0f,1f,1f);
        RigidbodyReference.AddForce(ForceDirection*force, ForceMode.Impulse);
    }

    public void Jump(float force){
        Vector3 ForceDirection = new Vector3(0f,1f,0f);
        RigidbodyReference.AddForce(ForceDirection*force);
    }
}
