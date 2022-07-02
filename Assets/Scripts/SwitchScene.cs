using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] private string loadScene;

    // Switch the scene if the Player hits the cheating portal
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Switching Scenes!");
            SceneManager.LoadScene(loadScene);
        }
    }
}
