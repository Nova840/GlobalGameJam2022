using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;
using GameJolt.API.Objects;
using TMPro;

public class HighScoreTable : MonoBehaviour
{

    private static List<HighScoreTable> allHighScoreTables = new List<HighScoreTable>();

    [SerializeField]
    private GameObject gameJoltAPIPrefab;

    private static GameObject gameJoltAPI;

    [SerializeField]
    private RectTransform scoreTemplate;

    [Min(0)]
    [SerializeField]
    private float spacing = 20;

    private void Awake() => allHighScoreTables.Add(this);
    private void OnDestroy() => allHighScoreTables.Remove(this);

    private void Start()
    {
        if (!gameJoltAPI)
            gameJoltAPI = Instantiate(gameJoltAPIPrefab);
        GetScores();
        scoreTemplate.gameObject.SetActive(false);
    }

    private static void GetScores() => Scores.Get(UpdateScores, 0, 10);
    private static void UpdateScores(Score[] scores)
    {
        foreach (HighScoreTable hst in HighScoreTable.allHighScoreTables)
        {
            for (int i = 0; i < scores.Length; i++)
            {
                RectTransform rt = Instantiate(hst.scoreTemplate, hst.transform).GetComponent<RectTransform>();
                rt.gameObject.SetActive(true);
                rt.anchoredPosition = new Vector2(hst.scoreTemplate.anchoredPosition.x, hst.scoreTemplate.anchoredPosition.y + (hst.spacing * (-i - 1)));
                rt.Find("Name Text").GetComponent<TMP_Text>().text = scores[i].PlayerName;
                rt.Find("Number Text").GetComponent<TMP_Text>().text = scores[i].Text;
            }
        }
    }

    public static void AddScore(int score, string name)
    {
        Scores.Add(score, score.ToString(), name, 0, "", (success) => { if (success) GetScores(); });
    }

}