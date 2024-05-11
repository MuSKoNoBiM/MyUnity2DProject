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
            _customer.TakedGoods += (Interactable) =>
            {
                string name;

                if (Interactable is Goods goods)
                    name = goods.transform.name;
                else
                    name = Interactable.ToString();

                Debug.Log($"The Customer took the {name}");
            };
        }

        public void Interact(IInteracter interacter)
        {
            if (interacter is null)
            {
                throw new ArgumentNullException(nameof(interacter));
            }

            Debug.Log("Interact with the Customer");
            _customer.Interact(interacter);
        }
    }
}
