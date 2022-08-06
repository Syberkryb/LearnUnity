using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : FriendlyAnimal
{
    HostileAnimal FleeFromWolf;
    
    // Start is called before the first frame update
    void Start()
    {
        FleeFromWolf = GameObject.FindObjectOfType<HostileAnimal>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, FleeFromWolf.transform.position, -1 * Time.deltaTime);
    }
}
