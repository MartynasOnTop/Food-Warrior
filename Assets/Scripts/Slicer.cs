using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    Rigidbody2D rb;

    public List<AudioClip> comboSounds;

    public int comboCount;
    public float comboTimeLeft;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;

        //transform.position = worldPos;
        rb.MovePosition(worldPos);

        comboTimeLeft -= Time.deltaTime;
        if (comboTimeLeft <= 0)
        {
            if (comboCount > 2)
            {
                AudioSystem.Play(comboSounds[comboCount - 3]);
                GameManager.score += comboCount;
            }
            comboCount = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(collision.gameObject);

        var fruit = collision.gameObject.GetComponent<Fruit>();
        fruit.Slice();

        comboCount++;
        GameManager.score++;
        comboTimeLeft = 0.2f;
    }
}
