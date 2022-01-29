using UnityEngine;

public sealed class PlayerHealthUI : MonoBehaviour
{
	[SerializeField]
	private RectTransform healtBarContainer;
	[SerializeField]
	private RectTransform healthBar;

	private float healthPercentage = 1;
	private float displayHealthPecentage = 1;

	private void Update()
	{
		displayHealthPecentage = Mathf.Lerp(displayHealthPecentage, healthPercentage, 10 * Time.unscaledDeltaTime);
		healthBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, HealthBarWidth);

		if (displayHealthPecentage == healthPercentage)
		{
			enabled = false;
		}
	}

	private float HealthBarWidth => healtBarContainer.rect.width * displayHealthPecentage;

	public void SetHeath(float healthPercentage)
	{
		this.healthPercentage = healthPercentage;
		enabled = true;
	}
}
