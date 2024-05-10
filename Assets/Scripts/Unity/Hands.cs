using UnityEngine;

namespace Unity
{
    public class Hands : MonoBehaviour
    {
        public GameObject Item;

        public void Take()
        {
            Item.SetActive(true);
        }

        public void SetToEmpty()
        {
            Item.SetActive(false);
        }
    }
}
