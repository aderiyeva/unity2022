using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{        
    private float enemySpeed = 0.02f;
    private Transform target;
    
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        // Don't do anything if game is "paused"
        if(Time.timeScale == 0)
        {
            return;
        }

        // Movement towards player if above, else move slowly downwards
        float dist = Vector3.Distance(target.position, transform.position);
        if(transform.position.y > target.position.y + 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed); 
        }
        else
        {
            transform.Translate(10*Vector3.down * enemySpeed * Time.deltaTime);
        }

        // Destroy if below a certain height
        if(transform.position.y < 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Destroy Enemy if hit by a bullet
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Bullet") 
        {
            Destroy(this.gameObject);
        }
    }
        
}  
 
