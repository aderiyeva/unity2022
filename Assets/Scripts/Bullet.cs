using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update() 
    {
        // Don't do anything if game is "paused"
        if(Time.timeScale == 0)
        {
            return;
        }

        // Move upwards at a certain speed
        transform.Translate((transform.up * speed * Time.deltaTime));

        // Destroy the bullet if above a certain height relative to the player
        if(transform.position.y > (player.transform.position.y + 10f))
        {
            Destroy(this.gameObject);
        }
    }

    // Destroy the bullet if an enemy is hit
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy") 
        {
            Destroy(this.gameObject);
        }
    }
}

