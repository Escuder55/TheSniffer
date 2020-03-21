using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject gameAudio;
    public GameObject Joystick;
    public GameObject SniffBar;

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }*/
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Joystick.SetActive(true);
        SniffBar.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        gameAudio.GetComponent<AudioSource>().UnPause();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Joystick.SetActive(false);
        SniffBar.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        gameAudio.GetComponent<AudioSource>().Pause();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        //CAMBIAR ESCENA POR LA DESEADA
        SceneManager.LoadScene("MartiScene");
    }
    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Debug.Log("Quittin game....");
        Application.Quit();
    }
}
