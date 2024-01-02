using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : MonoBehaviour
{
    private int DummyMaxHP = 100;
    private int DummyCurrentHP;

    private void Start()
    {
        DummyCurrentHP = DummyMaxHP;
    }

    public void TakeDamage(int damage)
    {
        DummyCurrentHP -= damage;

        if (DummyCurrentHP <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Dead");
    }


}
