using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FollowCharacter : MonoBehaviour
{
    #region VARIABLES
    public Transform player;
    [SerializeField] float recuperationSpeed;

    bool isOutside = false;
    #endregion

    #region UPDATE
    void Update()
    {
        if (isOutside)
        {
            this.transform.DOMove(player.position, recuperationSpeed);
        }
    }
    #endregion


    #region TRIGGER ENTER
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOutside = false;
        }
    }
    #endregion

    #region TRIGGER ENTER
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOutside = true;
        }
    }
    #endregion
}
