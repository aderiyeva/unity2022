using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnigScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If R is hit, restart the current scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
        
        // If Q is hit, quit the game
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("Application Quit");
            Application.Quit();
        }
    }
}
