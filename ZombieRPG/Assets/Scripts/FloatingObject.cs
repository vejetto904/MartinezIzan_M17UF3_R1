using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    // Variables para controlar la flotación
    public float floatSpeed = 1f; // Velocidad de flotación
    public float floatHeight = 0.5f; // Altura de flotación
    private Vector3 startPos; // Posición inicial

    // Variables para controlar la rotación
    public float rotateSpeed = 50f; // Velocidad de rotación

    void Start()
    {
        // Guarda la posición inicial del objeto
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
