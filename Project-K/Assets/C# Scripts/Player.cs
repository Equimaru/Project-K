using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private GameInput gameInput;

    public bool isRunning;


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
        transform.position += MoveDir * moveSpeed * Time.deltaTime;

        isRunning = MoveDir != Vector3.zero;

    }

    public bool IsRunning()
    {
        return isRunning;
    }
}
