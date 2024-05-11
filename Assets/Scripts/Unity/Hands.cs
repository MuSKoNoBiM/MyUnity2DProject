using System.Collections.Generic;
using UnityEngine;

namespace Unity
{
    public class Hands : MonoBehaviour
    {
        public List<GameObject> Items;

        private Dictionary<string, int> DictionayItems;
        private GameObject currentItem;

        private void Awake()
        {
            DictionayItems = new Dictionary<string, int>();
            OptimizeCollection();

            void OptimizeCollection()
            {
                Goods goods;

                for (int i = 0; i < Items.Count; i++)
                {
                    goods = Items[i].GetComponent<Goods>();

                    DictionayItems[goods.GetType().ToString()] = i;
                }
            }
        }

        public void Take(string name)
        {
            currentItem?.SetActive(false);
            currentItem = Items[DictionayItems[name]];

            currentItem.SetActive(true);
        }

        public void SetToEmpty()
        {
            currentItem.SetActive(false);
        }
    }
}
