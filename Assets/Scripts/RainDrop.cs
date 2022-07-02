using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -2)
        {
            Destroy(this.gameObject);
        }
    }

    // Destroy the raindrop once it hits the player or a platform
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" || collider.tag == "Platform") 
        {
            Destroy(this.gameObject);
        }
    }
}
