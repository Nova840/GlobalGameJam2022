using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveExitButtonForWebGL : MonoBehaviour
{

    [SerializeField]
    private RectTransform menuPanel;
    [SerializeField]
    private float webGLMenuPanelSizeY;
    [SerializeField]
    private RectTransform exitGameButton;

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            exitGameButton.gameObject.SetActive(false);
            menuPanel.sizeDelta = new Vector2(menuPanel.sizeDelta.x, webGLMenuPanelSizeY);
        }
    }

}
