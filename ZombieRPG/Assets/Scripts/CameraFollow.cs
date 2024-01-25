using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float distanceBehind = 10.0f; // Distancia detrás del jugador
    public float heightOffset = 2.0f; // Nueva variable para el desplazamiento en altura

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("No se ha asignado un objetivo para seguir en el script de CameraFollow.");
            return;
        }

        // Calcular la posición deseada de la cámara detrás y un poco más alta que el jugador
        Vector3 desiredPosition = target.position - target.forward * distanceBehind + Vector3.up * heightOffset;

        // Hacer que la cámara siga suavemente al jugador
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        transform.LookAt(target.position); // Asegurar que la cámara mire al jugador
    }
}
