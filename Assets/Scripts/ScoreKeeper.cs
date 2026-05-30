using UnityEngine;

public static class ScoreKeeper
{
    private static int score = 0;
    public static void AddPoint()
    {
        score++;
        // MonoBehaviour.print(score);
    }
    public static int GetScore()
    {
        return score;
    }
    public static void ResetScore()
    {
        score = 0;
    }
}
