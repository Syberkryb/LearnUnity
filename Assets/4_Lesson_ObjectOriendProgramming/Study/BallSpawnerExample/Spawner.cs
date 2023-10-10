using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawner class is responsible for spawning balls and controlling them
public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public float KickForce = 100.0f;
    public List<Ball> Balls = new List<Ball>();

    void Update()
    {
        //Spawn a ball when pressing Enter
        if (Input.GetKey(KeyCode.Return))
        {
            //Instantiate a ball at position (0, 1, 0) with no rotation
            GameObject spawnedPrefab = Instantiate(Prefab, new Vector3(0, 1, 0), Quaternion.identity);
            Ball ball = spawnedPrefab.GetComponent<Ball>();
            ball.RandomColor();
            ball.Kick(KickForce);
            Balls.Add(ball);
            spawnedPrefab.transform.SetParent(transform);
        }

        //Call Floaty() on all balls when pressing Space
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (Ball ball in Balls)
            {
                ball.Floaty(KickForce);
            }
        }
    }
}
