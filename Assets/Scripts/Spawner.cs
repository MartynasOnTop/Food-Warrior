using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruits;

    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 1f);
    }

    void Spawn()
    {
        var fruitCount = Random.Range(1, 5);

        for (int i = 0; i < fruitCount; i++)
        {
            var randomFruit = Random.Range(0, fruits.Length);
            var obt = Instantiate(fruits[randomFruit]);
            obt.transform.position = new Vector3(Random.Range(-5, 5), -6, 0);
        }
    }
}
