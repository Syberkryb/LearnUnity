using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public void Update()
    {
        foreach (HostileAnimal go in GameObject.FindObjectsOfType<HostileAnimal>())
        {
            if (Vector3.Distance(go.transform.position, transform.position) < 2.0f)
            {
                go.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            }
        }
    }
}
