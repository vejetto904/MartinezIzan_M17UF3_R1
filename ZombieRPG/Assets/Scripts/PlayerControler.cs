using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform hand; // Referencia al transform de la mano del jugador
    public Animator animator;

    private Vector3 originalScale; // Almacena la escala original del objeto

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador ha entrado en contacto con un objeto coleccionable
        if (other.CompareTag("Coleccionable"))
        {
            CollectObject(other.gameObject);
        }
    }

    void CollectObject(GameObject obj)
    {
        // Agrega aquí cualquier lógica adicional que desees ejecutar cuando se recolecte el objeto
        Debug.Log("¡Objeto recolectado!");
        animator.SetLayerWeight(animator.GetLayerIndex("Atack"), 1);

        // Almacena la escala original del objeto
        originalScale = obj.transform.localScale;

        // Desactiva la física del objeto recolectable para evitar problemas de interacción con el jugador
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Mueve el objeto a la posición de la mano del jugador y lo hace hijo de la mano
        obj.transform.parent = hand;
        obj.transform.localPosition = new Vector3(-0.05f, 0.25f, 0.05f); // Posición específica
        obj.transform.localRotation = Quaternion.Euler(new Vector3(3.95f, 6.7f, 86.63f)); // Rotación específica

        // Restaura la escala original del objeto
        obj.transform.localScale = originalScale;

        // Desactiva el collider para evitar que se detecten colisiones innecesarias mientras se lleva el objeto en la mano
        Collider col = obj.GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }

        // Elimina los scripts del objeto recolectado
        Destroy(obj.GetComponent<FloatingObject>());
    }
}
