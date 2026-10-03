using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int score = 0;

    public void addScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
    }
}