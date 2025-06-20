using UnityEngine;
using TMPro; // Necesario para TextMeshPro

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interacción")]
    public float interactionRange = 3f; // Rango de interacción
    public KeyCode interactionKey = KeyCode.E; // Tecla para interactuar
    public LayerMask interactableLayer; // Capa de objetos interactuables

    [Header("UI")]
    public GameObject interactionPrompt; // Mensaje "Presiona [E] para interactuar"
    public GameObject dialoguePanel; // Panel de diálogo (Canvas)
    public TextMeshProUGUI dialogueText; // Texto del diálogo (TextMeshPro)

    void Start()
    {
        // Ocultar UI al inicio
        interactionPrompt.SetActive(false);
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        CheckInteractable(); // Verifica si hay algo con lo que interactuar

        // Si hay un diálogo activo y el jugador presiona la tecla, avanzar
        if (dialoguePanel.activeSelf && Input.GetKeyDown(interactionKey))
        {
            dialoguePanel.SetActive(false);
        }
    }

    void CheckInteractable()
    {
        RaycastHit hit;
        bool canInteract = Physics.Raycast(
            transform.position,
            transform.forward,
            out hit,
            interactionRange,
            interactableLayer
        );

        interactionPrompt.SetActive(canInteract); // Muestra/oculta el mensaje

        if (canInteract && Input.GetKeyDown(interactionKey))
        {
            Interact(hit.collider.gameObject);
        }
    }

    void Interact(GameObject interactable)
    {
        Debug.Log("Interactuando con: " + interactable.name);

        // Ejemplo: Mostrar diálogo en pantalla
        if (interactable.GetComponent<InteractableObject>() != null)
        {
            string dialogue = interactable.GetComponent<InteractableObject>().dialogueText;
            dialogueText.text = dialogue;
            dialoguePanel.SetActive(true);
        }
    }
}