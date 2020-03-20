using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    GameObject []moveSpots;
    int idNextSpot;
    Transform nextSpot;
    bool isGoing = false;
    Rigidbody myRb;
    [SerializeField]int indexSpots = 1;
    // Start is called before the first frame update
    void Start()
    {
        switch (indexSpots)
        {
            case 1:
                moveSpots = GameObject.FindGameObjectsWithTag("MoveSpot");
                break;
            case 2:
                moveSpots = GameObject.FindGameObjectsWithTag("MoveSpot2");
                break;
            case 3:
                moveSpots = GameObject.FindGameObjectsWithTag("MoveSpot3");
                break;
            default:
                break;
        }
        
        idNextSpot = Random.Range(0,(moveSpots.Length - 1));
        nextSpot = moveSpots[idNextSpot].transform;
        transform.DOMove(nextSpot.transform.position, Random.Range(3,10));        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position == nextSpot.transform.position)
        {
            idNextSpot = Random.Range(0, (moveSpots.Length - 1));
            nextSpot = moveSpots[idNextSpot].transform;
            transform.DOMove(nextSpot.transform.position, Random.Range(3, 10));
        }
    }


}
