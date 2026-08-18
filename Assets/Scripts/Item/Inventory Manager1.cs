using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public Inventoryslots[] inventorySlots; // Array of inventory slots

    public int gold;
    public TMP_Text tMP_Text;
    public useItem useItem; // Reference to the useItem script
    public itamSO itamSO;
    public CanvasGroup canvasGroup;


    void Start()
    {
        // Initialize the inventory slots
        foreach (var slot in inventorySlots)
        {
            slot.UpdateUI();
        }
    }



    private void OnEnable()
    {
        Loot.OnLootPickedUp += AddItemToInventory; // Subscribe to the loot pickup event
    }

    private void OnDisable()
    {
        Loot.OnLootPickedUp -= AddItemToInventory; // Unsubscribe from the loot pickup event
    }

    public void AddItemToInventory(itamSO item, int quantity)
    {
        // Implement your logic to add the item to the player's inventory
        if (item.isGold)
        {
            gold += quantity;
            tMP_Text.text = gold.ToString();
            return; // Exit the method if the item is gold, as we don't need to add it to the inventory
        }
        else
        {
            foreach (var slot in inventorySlots)
            {
                if (slot.item == null)
                {
                    slot.item = item;
                    slot.quantity = quantity;
                    slot.UpdateUI();
                    break; // Exit the loop after adding the item to the first empty slot
                }
                else if (slot.item == item)
                {
                    slot.quantity += quantity;
                    slot.UpdateUI();
                    break; // Exit the loop after updating the quantity of an existing item
                }
            }
        }
        Debug.Log($"Picked up {quantity} x {item.itemName}");
        // You can also update the UI or perform other actions here
    }

    public void UseItem(Inventoryslots slot)
    {        

    if (slot.item == null)
        return;

    // Notenblatt
    if (slot.item.isMusicSheet)
    {
        if (canvasGroup.alpha == 0)
        {
            canvasGroup.alpha = 1;
        }
        else
        {
            canvasGroup.alpha = 0;
        }

        return;
    }

    // Normales Item
    if (slot.quantity > 0 && slot.item.isMusicSheet == false)
    {
        Debug.Log($"Using {slot.item.itemName}");

        useItem.ApplyItemEffect(slot.item);

        slot.quantity--;

        if (slot.quantity <= 0)
        {
            slot.item = null;
        }

        slot.UpdateUI();
    }
}


}


