using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittyButton : MonoBehaviour
{

    [SerializeField]
    private RectTransform kittyRectTransform;

    [SerializeField]
    private float moveSpeed;

    private RectTransform rectTransform;

    private bool kittyActive = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (!kittyActive)
        {
            StartCoroutine(MoveKitty());
        }
    }

    private IEnumerator MoveKitty()
    {
        kittyActive = true;
        float left = -rectTransform.sizeDelta.x + -kittyRectTransform.sizeDelta.x;
        float right = rectTransform.sizeDelta.x + kittyRectTransform.sizeDelta.x;
        kittyRectTransform.anchoredPosition = new Vector2(left, kittyRectTransform.anchoredPosition.y);
        kittyRectTransform.gameObject.SetActive(true);
        while (kittyRectTransform.anchoredPosition.x < right)
        {
            yield return null;
            kittyRectTransform.anchoredPosition += Vector2.right * (moveSpeed * Time.deltaTime);
        }
        kittyRectTransform.anchoredPosition = new Vector2(right, kittyRectTransform.anchoredPosition.y);
        kittyRectTransform.gameObject.SetActive(false);
        kittyActive = false;
    }

}