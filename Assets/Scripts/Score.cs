using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text textComponent;
    public GameStats gameStats;
    private int score = 0;

    void Update()
    {
        score++;
        textComponent.text = score + " m";
        gameStats.UpdateCurrentScore(score);
    }
}
