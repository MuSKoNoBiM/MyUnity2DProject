using UnityEngine;

public class Pause : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(Game.IsPaused);

        Program.Controls.Pause.Pause.performed += (arg)
            => gameObject.SetActive(Game.IsPaused);
    }
}
