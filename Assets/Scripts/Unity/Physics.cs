using Domain;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Unity
{
    public class Physics : IPhysics
    {
        private Camera _mainCamera;

        public Physics()
        {
            MainPhysics = this;
        }

        public void SetMainCamera(Camera mainCamera)
        {
            _mainCamera = mainCamera ?? throw new ArgumentNullException(nameof(mainCamera));
        }

        public static Physics MainPhysics { get; private set; }

        public bool TryRaycast(out IInteractable interactable)
        {
            interactable = null;

            RaycastHit2D hit = Physics2D.GetRayIntersection(
                _mainCamera.ScreenPointToRay(
                Mouse.current.position.ReadValue()));

            if (!hit.collider) return false;

            if (!hit.collider.transform.TryGetComponent(out IInteractable interactableResult))
                return false;

            interactable = interactableResult;
            return true;
        }
    }
}
