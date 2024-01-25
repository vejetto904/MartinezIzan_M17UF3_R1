using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float distanceBehind = 10.0f; // Distancia detr�s del jugador
    public float heightOffset = 2.0f; // Nueva variable para el desplazamiento en altura

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("No se ha asignado un objetivo para seguir en el script de CameraFollow.");
            return;
        }

        // Calcular la posici�n deseada de la c�mara detr�s y un poco m�s alta que el jugador
        Vector3 desiredPosition = target.position - target.forward * distanceBehind + Vector3.up * heightOffset;

        // Hacer que la c�mara siga suavemente al jugador
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        transform.LookAt(target.position); // Asegurar que la c�mara mire al jugador
    }
}
