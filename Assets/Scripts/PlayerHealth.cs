using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private float health = 1;

    public event Action<float> OnHealthChange;//<new health>

    public void Damage(float amount)
    {
        health -= amount;
        health = Mathf.Clamp01(health);
        if (health <= 0)
        {
            Debug.Log("Dead");
        }
        OnHealthChange?.Invoke(health);
    }

}