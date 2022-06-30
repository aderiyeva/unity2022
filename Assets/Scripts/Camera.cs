using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // IDEA - Camera should follow the player which is our target here 
    [SerializeField]
    private Transform target;
    public Vector3 offset; 

    public GameObject cheatportal;
    public GameObject cheatplatform;

    public float speedH = 2.0f;
    private float yaw = 0.0f;

    void Start()
    {
        offset = transform.position - target.transform.position; 
    }

    // LATEUPDATE - is called at the end of the frame 
    void LateUpdate()
    {
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
        transform.LookAt(target);
        transform.RotateAround (target.position, Vector3.up, yaw);
        
        if(yaw <= -15 || yaw >= 15) {
            GetComponent<Renderer>(cheatplatform) = (yaw - 15)/75;
            //cheatportal.renderer.material.color.a = (yaw - 15)/75;
        }
       
    }
}