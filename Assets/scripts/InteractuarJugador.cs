using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractuarJugador : MonoBehaviour
{
    public float interactRange = 3f;
    public LayerMask interactableLayer;
    public Text interactionText;

    private Interactable currentInteractable;

    void Update()
    {
        CheckForInteractable();

        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.red);

        if (Physics.Raycast(ray, out hit, interactRange, interactableLayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                currentInteractable = interactable;
                interactionText.text = interactable.interactionMessage;
                interactionText.enabled = true;
                return;
            }
        }

        currentInteractable = null;
        interactionText.enabled = false;
    }
}
