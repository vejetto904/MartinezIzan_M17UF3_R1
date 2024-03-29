using UnityEngine;

public class ItemReference : Interact
{
    public Item item;

    public override void InteractMeth()
    {
        if (Inventory.instance.Add(item))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Llama al método Update de la clase base
        base.Update();
    }
}
