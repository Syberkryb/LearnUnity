using System;
using System.Collections;
using System.Collections.Generic;
using Lesson_6;
using Lesson_6.Animals;
using UnityEngine;

public class AnimalPen : MonoBehaviour
{
    public List<Animal> Animals = new List<Animal>();

    public void SpawnAnimals(List<GameObject> anims)
    {
        for (int i = 0; i < anims.Count; i++)
        {
            Vector3 pos = transform.position;
            pos.y += 2;
            GameObject go = Instantiate(anims[i], pos, Quaternion.identity);
            go.transform.SetParent(transform);

            FriendlyAnimal animal = go.GetComponent<FriendlyAnimal>();
            Animals.Add(animal);
            animal.Pen = this;
        }
    }
}
