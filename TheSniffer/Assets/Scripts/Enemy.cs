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

    Animator myAnim;
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
        myAnim = this.GetComponent<Animator>();
        idNextSpot = Random.Range(0,(moveSpots.Length - 1));
        nextSpot = moveSpots[idNextSpot].transform;
        transform.DOMove(nextSpot.transform.position, Random.Range(3,10));
        selectAnim(this.transform.position, nextSpot.transform.position);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position == nextSpot.transform.position)
        {
            idNextSpot = Random.Range(0, (moveSpots.Length - 1));
            nextSpot = moveSpots[idNextSpot].transform;
            transform.DOMove(nextSpot.transform.position, Random.Range(3, 10));
            selectAnim(this.transform.position, nextSpot.transform.position);
        }
    }


    #region ANIMATIONCONTROLLER
    void selectAnim(Vector3 myPos, Vector3 nextPos)
    {
        float difY = nextPos.y - myPos.y;
        float difX = nextPos.x - myPos.x;
        //case going verticaly
        if (Mathf.Abs(difX) < Mathf.Abs(difY))
        {
            //GoingDown
            if (difY < 0)
            {
                myAnim.SetBool("Up", false);
                myAnim.SetBool("Right", false);
                myAnim.SetBool("Left", false);
                myAnim.SetBool("Down", true);
            }
            //GoingUp
            else
            {
                myAnim.SetBool("Right", false);
                myAnim.SetBool("Left", false);
                myAnim.SetBool("Down", false);
                myAnim.SetBool("Up", true);
            }
        }
        //case going horizontally
        else
        {
            //GoingLeft
            if (difX < 0)
            {
                myAnim.SetBool("Right", false);
                myAnim.SetBool("Down", false);
                myAnim.SetBool("Up", false);
                myAnim.SetBool("Left", true);
            }
            //GoingRight
            else
            {
                myAnim.SetBool("Down", false);
                myAnim.SetBool("Up", false);
                myAnim.SetBool("Left", false);
                myAnim.SetBool("Right", true);
            }
        }
    }
    #endregion

}
