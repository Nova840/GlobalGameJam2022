using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private Image fillImage;

    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponentInParent<Health>();
        playerHealth.OnHealthChange += OnHealthChange;
    }

    private void OnDestroy()
    {
        playerHealth.OnHealthChange -= OnHealthChange;
    }

    private void OnHealthChange(float healthPercentage)
    {
        fillImage.fillAmount = healthPercentage;
    }

}