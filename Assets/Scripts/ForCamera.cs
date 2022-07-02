using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForCamera : MonoBehaviour
{
    // IDEA - Camera should follow the player which is our target here 
    [SerializeField]
    private Transform target;
    public Vector3 offset; 

    public GameObject cheatportal;
    public GameObject cheatplatform;
    public Player player;

    public float speedH = 2.0f;
    private float yaw = 0.0f;

    void Start()
    {
        offset = transform.position - target.transform.position;
        // Making cheating elements transparent at first
        var color = cheatplatform.GetComponent<Renderer>().material.color; 
        var newColor = new Color(color.r, color.g, color.b, 0f); 
        cheatplatform.GetComponent<Renderer>().material.color = newColor;
        cheatportal.GetComponent<Renderer>().material.color = newColor;
    }

    // LATEUPDATE - is called at the end of the frame 
    void LateUpdate()
    {
        // Limiting the camera movement through the mouse
        yaw += speedH * Input.GetAxis("Mouse X");

        if(yaw <= -90) {
            yaw = -90;
        }
        if(yaw >= 90) {
            yaw = 90;
        }
        // NULL CHECK  
        if(target != null)
        {
            // ADD OFFSET - to our position in order to depict the player properly
            Vector3 newPosition = target.transform.position + offset;
            transform.position = newPosition; 
        }
        // Making sure that mouse camera novements float around the player
        transform.LookAt(target);
        transform.RotateAround (target.position, Vector3.up, yaw);

        // Changing the transparancy of cheat objects along with the camera angle
        if(yaw <= -15 || yaw >= 15) {
            var color = cheatplatform.GetComponent<Renderer>().material.color; 
            var newColor = new Color(color.r, color.g, color.b, (Mathf.Abs(yaw) - 15.0f)/75.0f);
            cheatportal.GetComponent<Renderer>().material.color = newColor; 
            cheatplatform.GetComponent<Renderer>().material.color = newColor;
            //cheatportal.renderer.material.color.a = (yaw - 15)/75;
        }
        
        // Changing the player movement according to the camera position
        if(yaw <= -75 || yaw >= 75) {
            if (yaw>0)
            {
               player.direction = Vector3.back; 
            }
            else
            {
                player.direction = Vector3.forward;
            }

        }
        else 
        {
            player.direction = Vector3.right;
        }
        
       
    }
}