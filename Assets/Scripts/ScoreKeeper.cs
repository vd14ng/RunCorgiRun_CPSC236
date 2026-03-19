using UnityEngine;

public static class ScoreKeeper
{
    private static int score = 0;
    public static void Add(int amount)
    {
        score = score + amount;
        // MonoBehaviour.print(score);
    }
    public static int GetScore()
    {
        return score;
    }
    public static void Reset()
    {
        score = 0;
    }
}
