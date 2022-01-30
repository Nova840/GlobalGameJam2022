using System;
using UnityEngine;

public sealed class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    private AudioSource OnHitSound;

    public int MaxHealth => maxHealth;

    private int currentHealth;
    public int CurrentHealth => currentHealth;

    public event Action<float> OnHealthChange;//<health percentage>
    public event Action OnDeath;

    private void Start()
        => currentHealth = maxHealth;

    public void Damage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChange?.Invoke((float)currentHealth / maxHealth);
        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }

        if (OnHitSound)
        {
            OnHitSound.Play();
        }
    }
}
