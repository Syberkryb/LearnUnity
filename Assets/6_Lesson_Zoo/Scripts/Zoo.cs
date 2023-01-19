using System.Collections;
using System.Collections.Generic;
using Lesson_6;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    public List<GameObject> AnimalPrefabs;
    public GameObject AnimalPenPrefab;

    public List<AnimalPen> Pens;
    public List<Animal> AllAnimals;

    void Start()
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

    private AnimalPen Spawner(int switcher)
    {
        //Spawn animal pen
        GameObject go = Instantiate(AnimalPenPrefab, transform);
        Vector3 spawnLocation = new Vector3((switcher + 1) * 50, 0, (switcher + 1) * 50);
        go.transform.SetPositionAndRotation(spawnLocation, Quaternion.identity);
        AnimalPen pen = go.GetComponent<AnimalPen>();

        //Spawn animals in the pen 
        switch (switcher)
        {
            case 0:
                Dictionary<GameObject, int> spawns = new Dictionary<GameObject, int>();
                spawns.Add(AnimalPrefabs[0], 5);
                pen.SpawnAnimals(spawns);
                break;

            case 1:
                int[][] matrix = new int[2][];
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i] = new int[3];
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] = 1;
                    }
                }

                pen.SpawnAnimals(AnimalPrefabs[0], matrix);
                break;

            case 2:
                int[,] matrixs = new int[2, 2];
                for (int i = 0; i < matrixs.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixs.GetLength(1); j++)
                    {
                        matrixs[i, j] = 1;
                    }
                }

                pen.SpawnAnimals(AnimalPrefabs[0], matrixs);
                break;

            case 3:
                List<GameObject> anims = new List<GameObject>();
                anims.Add(AnimalPrefabs[0]);
                anims.Add(AnimalPrefabs[0]);
                anims.Add(AnimalPrefabs[0]);
                anims.Add(AnimalPrefabs[0]);

                pen.SpawnAnimals(anims);
                break;

            case 4:
                HashSet<GameObject> set = new HashSet<GameObject>();
                set.Add(AnimalPrefabs[0]);
                set.Add(AnimalPrefabs[0]);

                pen.SpawnAnimals(set);
                break;

            default:
                break;
        }
        return pen;
    }
}
