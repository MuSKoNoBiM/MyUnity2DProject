using Domain;
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
            _clicker = new Domain.Clicker(Physics.MainPhysics);
        }

        private void OnClick(InputAction.CallbackContext context)
        {
            _clicker.OnClick();
        }

        private void OnTake(IInteractable interactable)
        {
            Hands.Take();
        }

        private void SetToEmpty()
        {
            Hands.SetToEmpty();
        }
    }
}
