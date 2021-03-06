﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationLogic : MonoBehaviour
{
    #region VARIABLES
    Transform player;
    public float timeIntensity;
    public float maxDistance;
    public float minDistance;
    public int numOfRanges = 4;
    int currentRange = 1;  

    float rangeDistance;
    float distanceToTarget = 0;
    float timer = 0;

    [Header("SNIFF BAR")]
    [SerializeField] Image sniffBar;

    [HideInInspector]
    public bool isPaused = false;
    #endregion

    #region START
    void Start()
    {
        player = GameObject.Find("Character").transform;
        rangeDistance = (maxDistance - minDistance) / numOfRanges;
    }
    #endregion

    #region UPDATE
    void Update()
    {
        if (!isPaused)
        {
            distanceToTarget = Vector3.Distance(this.transform.position, player.position);

            if (distanceToTarget <= maxDistance)
            {
                sniffBar.fillAmount = (10 - distanceToTarget) / 10;

                for (int i = 1; i <= numOfRanges; i++)
                {
                    if (distanceToTarget <= maxDistance && distanceToTarget >= maxDistance - rangeDistance * i)
                    {
                        currentRange = i;
                        break;
                    }
                }

                timer += Time.deltaTime;

                if (timer >= timeIntensity / currentRange)
                {
                    Handheld.Vibrate();
                    timer = 0;
                }

            }
            else
            {
                timer = 0;
            }
        }



        
    }
    #endregion

    #region DRAW GIZMOS
    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(this.transform.position, maxDistance);
    }
    #endregion

    #region TRIGGER ENTER
    public void ZeroSniffBar()
    {        
            sniffBar.fillAmount = 0;
    }
    #endregion
}
