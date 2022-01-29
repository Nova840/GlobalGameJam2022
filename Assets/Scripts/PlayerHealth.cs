using System;
using UnityEngine;

public sealed class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 1;

    public event Action<float> OnHealthChange;//<new health>
    public event Action OnDeath;

    public void Damage(float amount)
    {
        health -= amount;
        health = Mathf.Clamp01(health);
        OnHealthChange?.Invoke(health);

        if (health <= 0)
        {
            Debug.Log("Dead");
            OnDeath?.Invoke();
        }
    }
}