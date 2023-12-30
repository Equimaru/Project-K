using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInput : MonoBehaviour
{


    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

        return inputVector;
    }

    public bool GetAttackInteraction()
    {
        bool isAttacking = playerInputActions.Player.Attack.ReadValue<float>() != 0;
        return isAttacking;
    }
}