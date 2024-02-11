using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject fruitPrefab;

    public List<Wave> waves;

    async void Start()
    {
        foreach (var wave in waves)
        {
            await new WaitForSeconds(3f);
            foreach (var fruit in wave.fruits)
            {
                var prefab = fruit.isBomb ? bombPrefab : fruitPrefab;

                await new WaitForSeconds(fruit.delay);
                var go = Instantiate(prefab);

                go.transform.position = new Vector3(fruit.x, -5f, 0);

                var rb = go.GetComponent<Rigidbody2D>();
                rb.velocity = fruit.velocity;
            }
        }
    }

    void Spawn()
    {
        
    }
}
