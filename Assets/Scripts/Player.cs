using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    public float jumpHeight = 10f; // A public float so we can change its value easily in the inspector
    public static bool isJumping = false; // This bool will tell us if our character is jumping or not
    public Vector3 direction = Vector3.right;
    
    [SerializeField]
    private GameObject _bulletPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 2f, 0f);
    }

    // Update is called once per frame
    void PlayerMovement()
    {
        // Input based movement
        float verticalInput = Input.GetAxis("Vertical");  
        float horizontalInput = Input.GetAxis("Horizontal");    
        transform.Translate(direction* Time.deltaTime * _speed * horizontalInput);    
        if(transform.position.y < -10)
        {
            transform.position = new Vector3(0f, 2f, 0f);
        }

        if (Input.GetButtonDown("Jump") && (isJumping == false)) 
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpHeight, 0f), ForceMode.Impulse);
        }

    }
    // Jumping
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Platform" || collision.collider.tag == "cheat") 
        {
            isJumping = false;
        }
    }
    // Update is called once per frame
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Platform" || collision.collider.tag == "cheat")
        {
            isJumping = true;
        }
    }
    // Shooting bullets
    void Update()
    {
        PlayerMovement();

        // SPAWN BULLET 
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    // Enemy caused death
    private void OnTriggerEnter(Collider collision)
        {
            Debug.Log( collision.tag);
            if (collision.tag == "Bullet") 
                {
                    Destroy(this.gameObject);
                }
        }

}
