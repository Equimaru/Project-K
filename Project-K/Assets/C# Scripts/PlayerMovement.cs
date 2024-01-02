using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameInput gameInput;

    public bool isRunning;

    //private Vector2 lastInteractDir;

    private void Update()
    {
        PlayerMove();
    }
   

    private void PlayerMove() 
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        //Debug.Log(inputVector);

        if (inputVector.x > 0f)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (inputVector.x < 0f)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        Vector3 MoveDir = new(inputVector.x, inputVector.y / 2, 0f);

        if (MoveDir != Vector3.zero)
        {
            isRunning = true;
            //lastInteractDir = MoveDir;
        }
        else
        {
            isRunning = false;
        }

        float playerSize = 0.3f;
        bool canMove = !Physics2D.Raycast(transform.position, MoveDir, playerSize);

        if (canMove)
        {
            transform.position += Time.deltaTime * moveSpeed * MoveDir;
        }
    }

    public bool PlayerIsRunning()
    {
        return isRunning;
    }
}
