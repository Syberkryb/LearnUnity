using System.Collections;
using System.Collections.Generic;
using Lesson_6.Animals;
using UnityEngine;

namespace Lesson_6
{
    public class Arm : MonoBehaviour
    {
        protected void OnCollisionEnter(Collision collision)
        {
            print("Arm collided with " + collision.gameObject.name);
        }
    }
}
