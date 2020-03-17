using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    [Header("MOVEMENT")]
    [SerializeField] float moveSpeed = 5;
    public Rigidbody rb;
    public Joystick joystick;
    Vector3 movement;
    
    [Header("CONCENTRATION")]
    [SerializeField] Camera mainCamera;
    [SerializeField] float timeConcentration= 1.5f;
    [SerializeField] float speedTransition = 1.5f;
    [SerializeField] float newFov = 8f;
    bool isConcentrate = false;
    float initialFov;
    float timer = 0;
    #endregion

    #region START
    private void Start()
    {
        initialFov = mainCamera.orthographicSize;
    }
    #endregion

    #region UPDATE
    void Update()
    {
        //input teclado
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        //input mobil
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        movement.z = 0;

        if (movement == new Vector3(0,0,0))
        {            
            if (timer >= timeConcentration && !isConcentrate)
            {
                isConcentrate = true;
                mainCamera.DOOrthoSize(newFov, speedTransition);
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

        if (isConcentrate && movement != new Vector3(0, 0, 0))
        {
            timer = 0;
            isConcentrate = false;
            mainCamera.DOOrthoSize(initialFov, speedTransition);
        }
    }

    #endregion

    #region FIXED UPDATE
    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    #endregion
}
