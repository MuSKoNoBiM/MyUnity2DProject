using System;
using UnityEngine;

public static class Game
{
    public static bool IsPaused;

    public static event Action Started;
    public static event Action Paused;

    public static void Start()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        Started?.Invoke();
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
        IsPaused = true;
        Paused?.Invoke();
    }
}
