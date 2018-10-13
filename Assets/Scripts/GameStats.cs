using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "GameStats/Stats")]
public class GameStats : ScriptableObject {
    private int currentScore = 20;

    private List<int> highscores;

    public void OnEnable() {
        highscores = new List<int>() {100, 200, 50};
    }

    public void SetCurrentScore(int newScore) {
        if (currentScore > 0) {
            highscores.Add(currentScore);
        }
        currentScore = newScore;
    }

    public int GetCurrentScore() {
        return 20;
    }

    public List<int> GetHighscores() {
        highscores.Sort((a, b) => -1 * a.CompareTo(b));
        return highscores;
    }
}
