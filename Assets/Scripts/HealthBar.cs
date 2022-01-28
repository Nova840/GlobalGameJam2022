using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private Image fillImage = default;

    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
        playerHealth.OnHealthChange += OnHealthChange;
    }

    private void OnDestroy()
    {
        playerHealth.OnHealthChange -= OnHealthChange;
    }

    private void OnHealthChange(float health)
    {
        fillImage.fillAmount = health;
    }

}