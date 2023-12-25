using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    private const string ScoreKey = "ScoreKey";
    [SerializeField] private TextMeshProUGUI scoreText;
    private int _xp;

    private void Start()
    {
        PlayerPrefs.GetInt(ScoreKey);
        SetScore(0);
    }

    public void SetScore(int xp)
    {
        _xp += xp;
        scoreText.text = "Score:" + _xp;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(ScoreKey, _xp);
    }
}