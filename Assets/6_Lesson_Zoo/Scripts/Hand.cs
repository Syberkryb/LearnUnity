using System.Collections;
using System.Collections.Generic;
using Lesson_6.Animals;
using UnityEngine;

namespace Lesson_6
{
    public class Hand : MonoBehaviour
    {
        protected void OnCollisionEnter(Collision collision)
        {
            print("Hand collided with " + collision.gameObject.name);
        }
    }
}
