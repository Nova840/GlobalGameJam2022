using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;
using GameJolt.API.Objects;
using TMPro;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{

    [SerializeField]
    private GameObject gameJoltAPIPrefab;

    [SerializeField]
    private Button submitButton;

    [SerializeField]
    private TMP_InputField nameInputField;

    [SerializeField]
    private int maxCharsForName = 10;

    private static GameObject gameJoltAPI;

    [SerializeField]
    private RectTransform scoreTemplate;

    private List<GameObject> scoreElements = new List<GameObject>();

    [Min(0)]
    [SerializeField]
    private float spacing = 20;

    private void Start()
    {
        if (!gameJoltAPI)
            gameJoltAPI = Instantiate(gameJoltAPIPrefab);
        GetScores();
        scoreTemplate.gameObject.SetActive(false);
    }

    private void GetScores() => Scores.Get(UpdateScores, 0, 10);
    private void UpdateScores(Score[] scores)
    {
        foreach (GameObject se in scoreElements)
            Destroy(se);
        scoreElements.Clear();
        for (int i = 0; i < scores.Length; i++)
        {
            RectTransform rt = Instantiate(scoreTemplate, transform).GetComponent<RectTransform>();
            rt.gameObject.SetActive(true);
            rt.anchoredPosition = new Vector2(scoreTemplate.anchoredPosition.x, scoreTemplate.anchoredPosition.y + (spacing * -i));
            rt.Find("Name Text").GetComponent<TMP_Text>().text = scores[i].PlayerName;
            rt.Find("Number Text").GetComponent<TMP_Text>().text = scores[i].Text;
            scoreElements.Add(rt.gameObject);
        }
    }

    public void AddScore(int score, string name)
    {
        Scores.Add(score, score.ToString(), name, 0, "", AddScoreCallback);
    }

    private void AddScoreCallback(bool success)
    {
        if (success)
        {
            nameInputField.text = "";
            nameInputField.interactable = false;
            GetScores();
        }
        else
        {
            submitButton.interactable = true;
        }
    }

    public void OnSubmitButtonClick()
    {
        AddScore(ScoreManager.LoadScore(), nameInputField.text);
        submitButton.interactable = false;
    }

    public void OnNameInputFieldValueChanged()
    {
        nameInputField.text = nameInputField.text.Substring(0, Mathf.Clamp(nameInputField.text.Length, 0, maxCharsForName));
    }

}