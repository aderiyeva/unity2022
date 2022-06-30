using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    public float jumpHeight = 10f; // A public float so we can change its value easily in the inspector
    public static bool isJumping = false; // This bool will tell us if our character is jumping or not
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");  
        float horizontalInput = Input.GetAxis("Horizontal");    
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);    
        if(transform.position.y < -10)
        {
            transform.position = new Vector3(0f, 2f, 0f);
        }

        if (Input.GetButtonDown("Jump") && (isJumping == false)) 
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpHeight, 0f), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Platform" || collision.collider.tag == "cheat") 
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Platform" || collision.collider.tag == "cheat")
        {
            isJumping = true;
        }
    }

}
