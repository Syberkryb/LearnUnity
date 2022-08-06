using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : HostileAnimal
{
    FriendlyAnimal ChaseAnimal;
    
    // Start is called before the first frame update
    void Start()
    {
        ChaseAnimal = GameObject.FindObjectOfType<FriendlyAnimal>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, ChaseAnimal.transform.position, Time.deltaTime);
    }
}
