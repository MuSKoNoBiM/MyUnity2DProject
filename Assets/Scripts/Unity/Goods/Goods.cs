using Domain;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Unity
{
    public class Goods : MonoBehaviour, IInteractable
    {
        private Domain.Goods _goods;

        private void Awake()
        {
            _goods = new Domain.Goods(this);
        }

        public void Interact(IInteracter interacter)
        {
            if (interacter is null)
            {
                throw new ArgumentNullException(nameof(interacter));
            }

            Debug.Log($"Interact with the {transform.name}");
            _goods.Interact(interacter);
        }
    }
}
