using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_2 {
    public class Spawner : MonoBehaviour
    {
        public GameObject Prefab;

        public List<Ball> Balls;

        void Start()
        {
            Balls = new List<Ball>();
            RecursiveFibonacci(1,1,10);
        }

        private int RecursiveFibonacci(int first, int second, int count)
        {
            int next = first + second;

            for(int i = 0; i < next; i++){
                GameObject spawnedPrefab = Instantiate(Prefab, new Vector3(0, i, count), Quaternion.identity);
                Ball ball = spawnedPrefab.GetComponent<Ball>();
                Balls.Add(ball);
                spawnedPrefab.transform.SetParent(transform);
            }

            count--;
            if(count == 0) {
                return next;
            }else{
                return RecursiveFibonacci(second, next, count);
            }
        }
    }
}