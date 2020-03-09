using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] float moveSpeed = 5;
    [SerializeField] Rigidbody2D rb;
    Vector2 movement;
    #endregion

    // Update is called once per frame
    void Update()
    {
        //input   
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
