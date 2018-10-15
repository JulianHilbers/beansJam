using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "GameStats/Stats")]
public class GameStats : ScriptableObject
{
    [Header("Score")]
    public int currentScore = 0;
    public List<int> highscores;

    [Header("Gameplay")]
    public bool isScroreAfterPlay = false;
    public int playerLane;
    public int playerLaneCount;

    public void UpdateCurrentScore(int newScore)
    {
        currentScore = newScore;
    }

    public void AddHighScore(int newScore)
    {
        currentScore = newScore;

        if (highscores == null)
            highscores = new List<int>();


        if (currentScore > 0)
        {
            highscores.Add(currentScore);

            if (highscores.Count > 5)
                highscores.RemoveAt(0);
        }
    }

    public void IsFromGame(bool value)
    {
        isScroreAfterPlay = value;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public List<int> GetHighscores()
    {
        highscores.Sort((a, b) => -1 * a.CompareTo(b));
        return highscores;
    }

    public void SetPlayerLane(int lane)
    {
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

    public void PlayerLaneIncrement()
    {
        playerLaneCount += 1;
    }

    public void PlayerLaneReset()
    {
        playerLaneCount = 0;
    }
}
