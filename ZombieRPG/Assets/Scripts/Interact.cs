
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float radius = 3f;
    public bool isFocus = false;
    Transform player;
    public AudioSource pickUpSound; // Referencia al AudioSource

    public bool hasInteracted = false;

    public virtual void InteractMeth()
    {

    }
    private void Start()
    {
        // Buscar el objeto "pickup" en la escena y obtener su AudioSource
        GameObject pickupObject = GameObject.Find("pickUp");

        // Comprobar si se encontró el objeto
        if (pickupObject != null)
        {
            // Obtener el AudioSource del objeto "pickup"
            pickUpSound = pickupObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogWarning("Could not find 'pickup' object in the scene.");
        }
    }
    protected void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                InteractMeth();
                pickUpSound.Play();
                hasInteracted=true;
            }
        }
    }
    public void OnFocused (Transform PlayerTransform)
    {
        isFocus = true;
        player = PlayerTransform;
        hasInteracted = false;
    }
    public void DeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
