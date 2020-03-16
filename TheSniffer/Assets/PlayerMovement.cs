﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] float moveSpeed = 5;
    public Rigidbody rb;
    public Joystick joystick;
    Vector3 movement;
    #endregion

    // Update is called once per frame
    void Update()
    {
        //input teclado
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        //input mobil
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        movement.z = 0;
    }

    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
