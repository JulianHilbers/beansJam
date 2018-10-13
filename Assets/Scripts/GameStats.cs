using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "GameStats/Stats")]
public class GameStats : ScriptableObject {
    private int currentScore = 0;

    public List<int> highscores = new List<int>();
    public int playerLane;
    public int playerLaneCount;

    public void SetCurrentScore(int newScore) {
        currentScore = newScore;
    }

    public void SetNewHighScore(int newScore) {
        currentScore = newScore;

        if (currentScore > 0)
        {
            highscores.Add(currentScore);
        }
    }

    public int GetCurrentScore() {
        return currentScore;
    }

    public List<int> GetHighscores() {
        highscores.Sort((a, b) => -1 * a.CompareTo(b));
        return highscores;
    }

    public void SetPlayerLane(int lane){
        playerLane = lane;
    }

    public int GetPlayerLane()
    {
        return playerLane;
    }

    public int GetPlayerLaneCount()
    {
        return playerLaneCount;
    }

    public void PlayerLaneIncrement(){
        playerLaneCount += 1;
    }

    public void PlayerLaneReset(){
        playerLaneCount = 0;
    }
}
