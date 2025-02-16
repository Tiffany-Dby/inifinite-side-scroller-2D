using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score;

    void Update()
    {
        UpdateScoreText();
    }

    public void UpdateScore() => score++;

    public void UpdateScoreText() => scoreText.text = $"Score: {score}";
}
