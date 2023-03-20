using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_6.Animals
{
    public class Pig : FriendlyAnimal
    {
        protected float _rndStart;

        protected override void Start()
        {
            base.Start();
            _rndStart = Random.Range(0f, 5f);
        }

        protected void Update()
        {
            //Move up and down the z axis with a sin wave between initial amd IdleArea values times speed
            _rndStart += Time.deltaTime;
            transform.position = new Vector3(IdleCenter.x, IdleCenter.y, IdleCenter.z + (IdleArea * Mathf.Sin(_rndStart * speed)));
        }

        public override void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.GetComponent<Hand>() != null)
            {
                print("Pig was petted");
            }else if(collision.gameObject.GetComponent<Arm>() != null)
            {
                print("Pig was hit");
            }
        }
    }
}