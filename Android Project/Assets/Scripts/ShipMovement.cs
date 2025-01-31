﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float moveSpeed = 0.12f;
    private bool canMove = true;


    void Update()
    {
        if (GameController.gameOver)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }

    private void FixedUpdate()
    {
        MoveUpDown();
    }

    void MoveUpDown()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if(touchPos.y > 0 && touchPos.x > 1 && !Boundaries.topLimit && canMove)
            {
                //move up
                transform.Translate(0, moveSpeed, 0);
            }
            else if(touchPos.y < 0 && touchPos.x > 1 && !Boundaries.bottomLimit && canMove)
            {
                //move down
                transform.Translate(0, -moveSpeed, 0);
            }
        }
    }

    
}
