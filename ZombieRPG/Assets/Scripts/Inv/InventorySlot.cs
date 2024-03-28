using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.Sprite;
        icon.enabled = true;
    }

    public void RemoveItem()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            PlayerInputs PlayerInputs = FindObjectOfType<PlayerInputs>();
            if (PlayerInputs != null)
            {
                // Llamar al método para equipar el arma en la mano del jugador
                PlayerInputs.EquipItemInHand(item);
            }
        }
    }

    // Método para manejar el clic en el slot del inventario
    public void OnPointerClick(PointerEventData eventData)
    {
        UseItem();
    }
}
