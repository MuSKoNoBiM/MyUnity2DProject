using Domain;
using System;
using UnityEngine;

namespace Unity
{
    public class Customer : MonoBehaviour, IInteractable
    {
        private Domain.Customer _customer;

        private void Awake()
        {
            _customer = new Domain.Customer();
            _customer.TakedGoods += () => Debug.Log("The Customer took the goods");
        }

        public void Interact(IInteracter interacter)
        {
            if (interacter is null)
            {
                throw new ArgumentNullException(nameof(interacter));
            }

            Debug.Log("Interact with Customer");
            _customer.Interact(interacter);
        }
    }
}
