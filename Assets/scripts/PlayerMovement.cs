using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 8f; // Velocidad de giro (suavizado)
    public float strafeTiltAmount = 5f; // Inclinación al moverse lateralmente
    public float tiltSpeed = 4f; // Velocidad de la inclinación

    [Header("Referencias")]
    public Transform cameraPivot;
    public Animator animator;

    private Rigidbody rb;
    private float currentTilt; // Inclinación actual de la cámara

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (animator == null) animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Calculamos la dirección relativa a la cámara
        Vector3 camForward = cameraPivot.forward;
        Vector3 camRight = cameraPivot.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = (camForward * v + camRight * h).normalized;
        float moveMagnitude = moveDirection.magnitude;

        // Actualizamos el Animator
        animator.SetFloat("Velocidad", moveMagnitude);

        if (moveMagnitude > 0.1f)
        {
            // Movimiento
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

            // Rotación suavizada hacia la dirección de movimiento
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }

        // Inclinación lateral al moverse (efecto "strafe")
        float targetTilt = -h * strafeTiltAmount; // Inclinación deseada
        currentTilt = Mathf.Lerp(currentTilt, targetTilt, tiltSpeed * Time.fixedDeltaTime);
        cameraPivot.localEulerAngles = new Vector3(cameraPivot.localEulerAngles.x, cameraPivot.localEulerAngles.y, currentTilt);
    }
}