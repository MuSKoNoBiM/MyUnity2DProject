using Domain;
using System;
using UnityEngine;

namespace Unity
{
    public class Goods : MonoBehaviour, IInteractable
    {
        private Domain.Goods _goods;

        private void Awake()
        {
            _goods = new Domain.Goods();
        }

        public void Interact(IInteracter interacter)
        {
            if (interacter is null)
            {
                throw new ArgumentNullException(nameof(interacter));
            }

            Debug.Log("Interact with Goods");
            _goods.Interact(interacter);
        }
    }
}
