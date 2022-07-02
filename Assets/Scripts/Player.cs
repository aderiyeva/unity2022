using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab; // reference to the bullet prefab object
    [SerializeField] private float _speed = 5f; // player movement speed

    public Vector3 defaultSpawnPosition = new Vector3(0f, 2f, 0f);

    public float jumpHeight = 10f; 
    public static bool isJumping = false;
    public Vector3 direction = Vector3.right; // player movement axis
    
    [SerializeField] public float health = 100; // current health
    [SerializeField] public float maxHealth = 100; // maximum possible health
    public HealthBar healthBar; // reference to the UI healthbar element
    public bool alive; // player alive status

    // Start is called before the first frame update
    void Start()
    {
        // Player is alive at first
        alive = true;

        // Starting position
        transform.position = defaultSpawnPosition;
    }

    // Calculate the player movement based on inputs
    void PlayerMovement()
    {
        // Input based movement
        float verticalInput = Input.GetAxis("Vertical");  
        float horizontalInput = Input.GetAxis("Horizontal");    
        transform.Translate(direction * Time.deltaTime * _speed * horizontalInput);

        // If the player falls below the map, respawn it at the starting location
        if(transform.position.y < -10)
        {
            transform.position = defaultSpawnPosition;
            TakeDamage(25);
        }

        // To make the player jump, a vertical impulse force is applied
        if (Input.GetButtonDown("Jump") && (isJumping == false)) 
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpHeight, 0f), ForceMode.Impulse);
        }

    }

    // Player is not currently jumping when touching the ground 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Platform" || collision.collider.tag == "cheat") 
        {
            isJumping = false;
        }
    }

    // Player is currently jumping when not touching the ground 
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Platform" || collision.collider.tag == "cheat")
        {
            isJumping = true;
        }
    }

    void Update()
    {
        if(alive)
        {
            // Process player movements
            PlayerMovement();

            // Create bullet when shooting
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            }

            // Set player status to dead if health drops below zero
            if(health <= 0)
            {
                alive = false;
                Time.timeScale = 0;
            }
        }
    }

    // If player comes into contact with an enemy or rain, take damage
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy") 
        {
            TakeDamage(25);
        }
        if (collision.tag == "RainDrop") 
        {
            TakeDamage(5);
        }
    }

    // Apply damage to player and update UI healthbar
    public void TakeDamage(float damage)
    {    
        health -= damage;

        // Restrict health to zero to avoid weird UI changes
        health = Mathf.Max(health, 0f);

        healthBar.UpdateHealthBar();  
    }
}
