using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_6.Animals
{
    public abstract class FriendlyAnimal : Animal, IFriendlyAnimal
    {
        public AnimalPen Pen;

        public virtual void OnMouseDown()
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }

        public virtual void OnCollisionEnter(Collision collision){
            print("FriendlyAnimal collided with " + collision.gameObject.name);
        }
    }
}