using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField] private GameInput gameInput;

    [SerializeField] private LayerMask interactLayerMask;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;

    private int damage = 20;

    private bool isAttacking;

    private void Update()
    {
        isAttacking = gameInput.IsPlayerAttacking();
        if (isAttacking)
        {
            PlayerAttack();
        }
    }

    private void PlayerAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, interactLayerMask);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<TrainingDummy>().TakeDamage(damage);
        }

    }

    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public bool PlayerIsAttacking()
    {
        return isAttacking;
    }
}
