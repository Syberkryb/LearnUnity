using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_6.Animals
{
    public class Cat : FriendlyAnimal
    {
        private float _angle = 0f; // The current angle of _startPosition

        protected override void Start()
        {
            base.Start();
            _angle = Random.Range(0f, 360f);
        }

        public override void OnMouseDown()
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        protected void Update()
        {
            // Calculate the position of the orbit based on the IdleCenter and the current angle
            Vector3 orbitPosition = new Vector3(
                IdleCenter.x + (IdleArea * Mathf.Cos(_angle)),
                IdleCenter.y,
                IdleCenter.z + (IdleArea * Mathf.Sin(_angle))
                );

            // Move the object to the orbit position
            transform.position = orbitPosition;

            // Increase the angle based on the speed
            _angle += speed * Time.deltaTime;
        }
    }
}