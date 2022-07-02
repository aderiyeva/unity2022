using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Adding constant rotation to the finishing element
    void Update()
    {
        transform.Rotate(new Vector3 (0f, 0f, 50f) * Time.deltaTime);
    }
}
