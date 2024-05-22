using Domain;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Unity
{
    public static class OwnPhysics
    {
        public static bool TryRaycast(out IInteractable interactable)
        {
            interactable = null;

            RaycastHit2D hit = Physics2D.GetRayIntersection(
                Camera.main.ScreenPointToRay(
                Mouse.current.position.ReadValue()));

            if (!hit.collider) return false;

            if (!hit.collider.transform.TryGetComponent(out IInteractable interactableResult))
                return false;

            interactable = interactableResult;
            return true;
        }
    }
}
