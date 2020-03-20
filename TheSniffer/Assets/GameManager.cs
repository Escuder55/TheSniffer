using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject [] myLockers;
    int totalObjects = 0; //OBJETOS TOTALES
    int objectsFound = 0; //OBJETOS ENCONTRADOS
    float countdownTimer = 120; //TIEMPO EN ESCENA
    [SerializeField] GameObject youLose;
    [SerializeField] GameObject youWin;
    // Start is called before the first frame update

    [Header("HUD")]
    [SerializeField] Text objectsText;
    [SerializeField] Text timeHUDText;

    //TIEMPO
    int min;
    int sec;

    void Start()
    {
        myLockers = GameObject.FindGameObjectsWithTag("Locker");
        foreach (var GameObject in myLockers)
        {
            if (GameObject.GetComponent<LockerScript>().hasObject)
            {
                totalObjects++;
            }
        }
        Debug.Log("Total objects to find = " + totalObjects);

        //SETTEAMOS HUD INICIAL
        objectsText.text = (objectsFound.ToString() + " / " + totalObjects.ToString());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //SEGUNDOS Y MINUTOS
        min = Mathf.FloorToInt(countdownTimer / 60);
        sec = Mathf.FloorToInt(countdownTimer % 60);

        //HUD TIMER
        if(sec < 10)
        {
            timeHUDText.text = ("0" + min.ToString() + ":" + "0" + sec.ToString());
        }
        else
        {
            timeHUDText.text = ("0" + min.ToString() + ":" + sec.ToString());
        }

        countdownTimer -= Time.deltaTime;
        if ((objectsFound==totalObjects) ||(countdownTimer<=0))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (objectsFound == totalObjects)
        {
            youWin.SetActive(true);
        }
        else
            youLose.SetActive(true);

    }

    public void objectFound()
    {
        objectsFound++;

        //ACTUALIZAMOS OBJETOS ENCONTRADOS
        objectsText.text = (objectsFound.ToString() + " / " + totalObjects.ToString());
    }
}
