using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [TextArea(3, 10)] // Hace que el cuadro de texto sea más grande en el Inspector
    public string dialogueText = "¡Hola! Esto es un diálogo de ejemplo.";
}