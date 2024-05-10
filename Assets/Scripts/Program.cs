using UnityEngine;

namespace My2DProject
{
    public static class Program
    {
        private static Unity.Physics _physics;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Main_BeforeSceneLoad()
        {
            _physics = new Unity.Physics();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Main_AfterSceneLoad()
        {
            _physics.SetMainCamera(Camera.main);
        }
    }
}
