using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject explodeParticles;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, Random.Range(9, 14));
        rb.angularVelocity = Random.Range(-360, 360);
    }
    private void Update()
    {
        if (transform.position.y < -6)
        {
            Miss();
        }
    }
    void Miss()
    {
        print(":(");
        Destroy(gameObject);
    }

    public void Slice()
    {
        var particles = Instantiate(explodeParticles);
        particles.transform.position = transform.position;

        Destroy(gameObject);
    }
}
