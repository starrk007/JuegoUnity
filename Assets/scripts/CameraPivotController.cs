using UnityEngine;

public class CameraPivotController : MonoBehaviour
{
    public float mouseSensitivity = 3f;
    float yRotation = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        yRotation += mouseX;
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}