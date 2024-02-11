using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject explodeParticles;
    public AudioClip spawnSound;
    public AudioClip sliceSound;
    public Color fruitColor;
    public AudioClip missSound;
    public AudioClip gameOver;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = Random.Range(-360, 360);
        AudioSystem.Play(spawnSound);
    }
    private void Update()
    {
        if (transform.position.y < -20)
        {
            Miss();
        }
    }
    void Miss()
    {
        if (!CompareTag("Bomb"))
        {
            AudioSystem.Play(missSound);
            GameManager.health -= 1;
            if (GameManager.health <= 0)
            {
                AudioSystem.Play(gameOver);
                Time.timeScale = 0f;
            }
        }
        Destroy(gameObject);
    }

    public void Slice()
    {
        var particles = Instantiate(explodeParticles);
        particles.transform.position = transform.position;

        if (!CompareTag("Bomb")) Split(particles);
        AudioSystem.Play(sliceSound);

        if (CompareTag("Bomb"))
        {
            GameManager.health = 0;
            Time.timeScale = 0f;
        }

        if (CompareTag("Start")) SceneManager.LoadScene("GamePlay");

        Destroy(gameObject);
    }

    void Split(GameObject particles)
    {
        var children = GetComponentsInChildren<MeshRenderer>();
        particles.GetComponent<ParticleSystem>().startColor = fruitColor;
        particles.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = fruitColor;
        foreach (var child in children)
        {
            var childRb = child.gameObject.AddComponent<Rigidbody2D>();
            childRb.velocity = rb.velocity + Random.insideUnitCircle;
        }
        transform.DetachChildren();
    }
}
