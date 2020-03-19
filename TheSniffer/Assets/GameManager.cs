using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject [] myLockers;
    int totalObjects = 0;
    int objectsFound = 0;
    float countdownTimer=10;
    [SerializeField] GameObject youLose;
    [SerializeField] GameObject youWin;
    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
    }
}
