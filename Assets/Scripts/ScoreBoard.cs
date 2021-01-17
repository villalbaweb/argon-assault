using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    TMP_Text _scoreText;
    int score;

    private void Awake() 
    {
        _scoreText = GetComponent<TMP_Text>();
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        _scoreText.text = $"Score: {score}";
    }
}
