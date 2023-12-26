using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private GameInput gameInput;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;



    private Vector2 movementInput;

    private Rigidbody2D rb;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        if (inputVector != Vector2.zero)
        {
            int count = rb.Cast(
                movementInput,
                movementFilter,
                castCollisions,
                moveSpeed + Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                Vector3 MoveDir = new Vector3(inputVector.x, inputVector.y, 0f);
                transform.position += MoveDir * moveSpeed * Time.fixedDeltaTime;
            }
        }
    }

    
}
