using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text restartText;

    public Player player;

    private bool isGameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        // At first hide the gameover elements
        gameOverPanel.SetActive(false);
        restartText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Trigger game over manually and check with bool so it isn't called multiple times
        if (Input.GetKeyDown(KeyCode.G) && !isGameOver)
        {
            Debug.Log("Manual GameOver");            
            Time.timeScale = 0;
            StartCoroutine(GameOverSequence());
        }
        
        // If game is over
        if (isGameOver)
        {
            // If R is hit, restart the current scene
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
            // If Q is hit, quit the game
            if (Input.GetKeyDown(KeyCode.Q))
            {
                print("Application Quit");
                Application.Quit();
            }
        }

        // Trigger game over if time is paused, the player is dead and the game isn't over (so it isn't called multiple times)
		bool timeHasStopped = Time.timeScale == 0;
        bool playerIsDead = !player.alive;
        if (timeHasStopped && playerIsDead && !isGameOver)
        {
            StartCoroutine(GameOverSequence());
		}
    }

    // Controls game over canvas and there's a brief delay between main Game Over text and option to restart/quit text
    private IEnumerator GameOverSequence()
    { 
        isGameOver = true;
        gameOverPanel.SetActive(true);

        // Wait in realtime seconds because gametime is paused on game over
        yield return new WaitForSecondsRealtime(2f);

        restartText.gameObject.SetActive(true);
    }
}
