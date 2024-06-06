using UnityEngine;

public static class Program
{
    public static Controls Controls { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Main()
    {
        Controls = new Controls();

        Game.IsPaused = false;
        Controls.Pause.Pause.performed += (arg) => OnPause();

        void OnPause()
        {
            if (Game.IsPaused)
            {
                Debug.Log("Start");
                Game.Start();
            }
            else
            {
                Debug.Log("Pause");
                Game.Pause();
            }
        }
    }
}
