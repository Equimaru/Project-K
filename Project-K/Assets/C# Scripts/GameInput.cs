using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInput : MonoBehaviour
{

    private bool isAttacking;
    private bool isInteracting;

    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Attack.performed += Attack_performed;
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isInteracting = true;
    }

    private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isAttacking = true;
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

        return inputVector;
    }

    public bool IsPlayerAttacking()
    {
        bool isPlayerAttacking = isAttacking;
        isAttacking = false;
        return isPlayerAttacking;
    }

    public bool IsPlayerInteracting()
    {
        bool isPlayerInteracting = isInteracting;
        isInteracting = false;
        return isPlayerInteracting;
    }
}