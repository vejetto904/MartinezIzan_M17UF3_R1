using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float speed = 2.0f;          // Velocidad de movimiento del jugador
    public float rotationSpeed = 50.0f; // Velocidad de rotación del jugador
    public float jumpForce = 5.0f;      // Fuerza del salto
    public float runMultiplier = 2.0f;  // Factor de multiplicación para la velocidad al correr

    private bool isWalking = false; // Variable para controlar si el personaje está caminando
    private bool isRunning = false; // Variable para controlar si el personaje está corriendo

    private void Awake()
    {
        InputController.Instance ??= FindObjectOfType<InputController>();
        InputController.Caminar += StartWalking;
        InputController.Correr += StartRunning;
        InputController.Jump += Jump;
    }

    private void OnDestroy()
    {
        InputController.Caminar -= StartWalking;
        InputController.Correr -= StartRunning;
        InputController.Jump -= Jump;
    }

    private void StartWalking(bool walking)
    {
        isWalking = walking;
    }

    private void StartRunning()
    {
        isRunning = true;
    }

    //private void StopRunning()
    //{
    //    isRunning = false;
    //}
    private void Jump()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Verificar si el jugador está caminando o corriendo
            if (isWalking || isRunning)
            {
                // Verificar si la velocidad en el eje Y es cercana a cero
                if (Mathf.Abs(rb.velocity.y) < 0.01f)
                {
                    // Aplicar la fuerza de salto solo si la velocidad en Y es baja
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
            }
        }
    }



    private void Update()
    {
        if (isWalking || isRunning)
        {
            Vector2 movementInput = InputController.Instance.movimientoActual;

            float horizontalInput = movementInput.x;
            float verticalInput = movementInput.y;

            // Calcular la velocidad multiplicando por el factor de correr si el personaje está corriendo
            float currentSpeed = speed * (isRunning ? runMultiplier : 1.0f);

            // Calcular el vector de movimiento
            Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * currentSpeed * Time.deltaTime;

            // Mover al jugador en la dirección del vector de movimiento
            transform.Translate(movement);

            // Rotar al jugador basado en la entrada de rotación
            float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
        }
    }
}
