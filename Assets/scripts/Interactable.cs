using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactionMessage = "Presiona E para interactuar";

    public virtual void Interact()
    {
        Debug.Log("Interacción base con " + gameObject.name);
        // Aquí puedes sobreescribir esto en herencias si deseas.
    }
}
