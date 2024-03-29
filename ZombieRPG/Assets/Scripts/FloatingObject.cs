using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    // Variables para controlar la flotaci�n
    public float floatSpeed = 1f; // Velocidad de flotaci�n
    public float floatHeight = 0.5f; // Altura de flotaci�n
    private Vector3 startPos; // Posici�n inicial

    // Variables para controlar la rotaci�n
    public float rotateSpeed = 50f; // Velocidad de rotaci�n

    void Start()
    {
        // Guarda la posici�n inicial del objeto
        startPos = transform.position;
    }

    void Update()
    {
        // Hace que el objeto flote en el eje Y
        transform.position = new Vector3(transform.position.x,
                                         startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight,
                                         transform.position.z);

        // Hace que el objeto rote continuamente
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
