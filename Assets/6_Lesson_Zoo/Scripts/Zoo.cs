using System.Collections.Generic;
using Lesson_6.Animals;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    public List<GameObject> AnimalPrefabs;
    public GameObject AnimalPenPrefab;

    public List<AnimalPen> Pens;
    public List<Animal> AllAnimals;

    protected void Start()
    {
        Pens = new List<AnimalPen>();
        AllAnimals = new List<Animal>();

        for (int i = 0; i < 10; i++)
        {
            AnimalPen pen = Spawner(i);
            AllAnimals.AddRange(pen.Animals);
            Pens.Add(pen);
        }
    }

    private AnimalPen Spawner(int counter)
    {
        //Spawn animal pen
        GameObject go = Instantiate(AnimalPenPrefab, transform);
        Vector3 spawnLocation = new Vector3(25 + (counter * 50), 0, 25);
        go.transform.SetPositionAndRotation(spawnLocation, Quaternion.identity);
        AnimalPen pen = go.GetComponent<AnimalPen>();

        List<GameObject> spawns = new List<GameObject>();
        spawns.Add(AnimalPrefabs[0]);
        pen.SpawnAnimals(spawns);

        return pen;
    }
}
