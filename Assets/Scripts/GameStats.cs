using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "GameStats/Stats")]
public class GameStats : ScriptableObject {
    private int currentScore;

    private List<int> highscores;

    public void OnEnable() {
        highscores = new List<int>();
    }

    public void SetCurrentScore(int newScore) {
        if (currentScore > 0) {
            highscores.Add(currentScore);
        }
        currentScore = newScore;
    }

    public int GetCurrentScore() {
        return currentScore;
    }

    public List<int> GetHighscores() {
        return highscores;
    }
}
