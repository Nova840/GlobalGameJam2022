using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private Image fillImage;

    private Health playerHealth;

    private float fillAmount = 1;

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
        fillAmount = healthPercentage;
    }

    private void Update()
    {
        fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, fillAmount, 10 * Time.unscaledDeltaTime);
    }

}