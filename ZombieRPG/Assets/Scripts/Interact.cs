
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float radius = 3f;
    public bool isFocus = false;
    Transform player;

    public bool hasInteracted = false;

    public virtual void InteractMeth()
    {

    }
    protected void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                InteractMeth();
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
