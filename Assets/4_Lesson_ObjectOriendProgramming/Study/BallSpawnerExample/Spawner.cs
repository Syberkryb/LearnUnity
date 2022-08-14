using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public float KickForce = 50.0f;
    public List<Ball> Balls;

    void Start()
    {
        Balls = new List<Ball>();
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.Return)){ //Spawn
            GameObject spawnedPrefab = Instantiate(Prefab, new Vector3(0,1,0), Quaternion.identity);
            Ball ball = spawnedPrefab.GetComponent<Ball>();
            ball.RandomColor();
            ball.Kick(KickForce);
            Balls.Add(ball);
            spawnedPrefab.transform.SetParent(transform);
        }

        if(Input.GetKey(KeyCode.Space)){
            foreach(Ball ball in Balls){
                ball.Jump(KickForce);
            }
        }
    }
}
