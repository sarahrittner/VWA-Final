using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.UI;
using System.Collections;

public class SHopManager : MonoBehaviour
{
    [SerializeField] private List<ShopItems> shopItems; 

    [SerializeField] private Shop[] shopSlots; // Array of Shopslot components representing the UI slots in the shop
    [SerializeField] private InventoryManager inventoryManager; // Reference to the InventoryManager script

    public void Start()
    {
        PopulateShopItems();
    }

    public void PopulateShopItems()
    {
        for (int i = 0; i < shopSlots.Length && i < shopItems.Count; i++)
        {
            ShopItems shopItem = shopItems[i];
            if (i < shopItems.Count)
            {
                // Populate the shop slot with the item and price
                shopSlots[i].Initialize(new itamSO[] { shopItems[i].item }, new int[] { shopItems[i].price });
                shopSlots[i].gameObject.SetActive(true); // Ensure the shop slot is active
            }
            else
            {
                // Clear the shop slot if there are no more items to display
                shopSlots[i].Initialize(new itamSO[0], new int[0]);
                shopSlots[i].gameObject.SetActive(false); // Ensure the shop slot is inactive
            }
        }
    }

    

    [System.Serializable]
    public class ShopItems
    {
        public itamSO item; // Reference to the item scriptable object
        public int price; // Price of the item
    }

    public void TryBuyItem(itamSO item, int price)
    {
        if (inventoryManager.gold >= price && item != null)
        {
            inventoryManager.gold -= price; // Deduct the price from the player's gold
            inventoryManager.tMP_Text.text = inventoryManager.gold.ToString(); // Update the gold display
            inventoryManager.AddItemToInventory(item, 1); // Add the item to the player's inventory
        }
        else
        {
            Debug.Log("Not enough gold to buy this item.");
        }
    }


}
