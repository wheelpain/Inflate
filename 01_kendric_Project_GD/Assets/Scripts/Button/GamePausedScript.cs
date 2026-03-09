using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedScript : MonoBehaviour
{
    public GameObject pausedMenu;
    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Paused()
    {
        pausedMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void UnPaused()
    {
        pausedMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                UnPaused();
            else
                Paused();
        }
       
    }
}

