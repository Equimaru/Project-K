using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public event EventHandler OnAttackAttenpt;



    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameInput gameInput;

    public bool isRunning;

    //private Rigidbody2D rigidbody2;

    //private float thrust = 1f;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Debug.Log(inputVector);

        if (inputVector.x > 0f)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (inputVector.x < 0f)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        Vector3 MoveDir = new Vector3(inputVector.x, inputVector.y / 2, 0f);

        float playerSize = 0.3f;
        bool canMove = !Physics2D.Raycast(transform.position, MoveDir, playerSize);

        if (canMove)
        {
            transform.position += MoveDir * moveSpeed * Time.deltaTime;
        }

        isRunning = MoveDir != Vector3.zero;

    }

    /*private void FixedUpdate()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        rigidbody2 = GetComponent<Rigidbody2D>();
        //rigidbody2.AddForce(inputVector * thrust, ForceMode2D.Impulse);
        rigidbody2.velocity = inputVector * moveSpeed;

        isRunning = inputVector != Vector2.zero;
        
        Debug.Log(inputVector);

        if (inputVector.x > 0f)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (inputVector.x < 0f)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }*/

    public bool IsRunning()
    {
        return isRunning;
    }

    public bool IsAttacking()
    {
        return gameInput.GetAttackInteraction();
    }
}
