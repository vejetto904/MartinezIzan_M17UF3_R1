using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float speed = 5.0f;          // Velocidad de movimiento del jugador
    public float rotationSpeed = 100.0f; // Velocidad de rotación del jugador

    void Update()
    {
        // Obtener la entrada del teclado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * speed * Time.deltaTime;

        // Mover al jugador en la dirección del vector de movimiento
        transform.Translate(movement);

        // Rotar al jugador basado en la entrada de rotación
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
