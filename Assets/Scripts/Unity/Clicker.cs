using Domain;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Unity
{
    public class Clicker : MonoBehaviour
    {
        public Hands Hands;
        private Controls _controls;
        private Domain.Clicker _clicker;

        private void OnEnable()
        {
            _controls.Interaction.Interact.performed += OnClick;
            _controls.Enable();

            _clicker.Taked += OnTake;
            _clicker.Given += SetToEmpty;
        }

        private void OnDisable()
        {
            _controls.Interaction.Interact.performed -= OnClick;
            _controls.Disable();

            _clicker.Taked -= OnTake;
            _clicker.Given -= SetToEmpty;
        }

        private void Awake()
        {
            _controls = new Controls();
            _clicker = new Domain.Clicker();
        }

        private void OnClick(InputAction.CallbackContext context)
        {
            if (OwnPhysics.TryRaycast(out IInteractable interactable))
                _clicker.OnClick(interactable);
        }

        private void OnTake(IInteractable interactable)
        {
            if (interactable is null)
            {
                throw new ArgumentNullException(nameof(interactable));
            }

            Hands.Take(interactable.GetType().ToString());
        }

        private void SetToEmpty()
        {
            Hands.SetToEmpty();
        }
    }
}
