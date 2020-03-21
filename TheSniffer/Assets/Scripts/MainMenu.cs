using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        int randomMap = Random.Range(1, 3);
        Debug.Log(randomMap);

        switch(randomMap)
        {
            case 1:
                SceneManager.LoadScene("Mapa1");
                break;
            case 2:
                SceneManager.LoadScene("Mapa2");
                break;
            default:
                break;
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
