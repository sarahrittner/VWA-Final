using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;
using System.Collections;


public class Inventoryslots : MonoBehaviour, IPointerClickHandler
{
    public itamSO item; // Reference to the item scriptable object
    public int quantity; // Quantity of the item
    public Image image; // Reference to the Image component for displaying the item sprite
    public TMP_Text quantityText; // Reference to the TextMeshProUGUI component for displaying the quantity
    private InventoryManager inventoryManager; // Reference to the InventoryManager script
    private SHopManager shopManager; // Reference to the ShopManager script
    private PlayerController playerController; // Reference to the PlayerController script

    private Shop shop; // Reference to the Shop script

    private void Start()
    {
        inventoryManager = GetComponentInParent<InventoryManager>();

    }


    private void OnEnable()
    {
        SHopManager.OnShopStateChanged += HandleShopStateChanged; // Subscribe to the shop state change event
        
    }

    private void OnDisable()
    {
        SHopManager.OnShopStateChanged -= HandleShopStateChanged; // Unsubscribe from the shop state change event
    }

    private void HandleShopStateChanged(SHopManager shOpManager, bool isOpen)
    {
        shopManager = isOpen ? shOpManager : null; // Store the reference to the shop manager when the shop is open        


    }

    public void UpdateUI()
    {
        if (quantity <= 0)
        {
            item = null;
        }

        if (item != null)
        {
            image.sprite = item.itemSprite; // Set the item sprite
            image.gameObject.SetActive(true); // Enable the image
            quantityText.text = quantity.ToString(); // Update the quantity text
        }
        else
        {
            image.gameObject.SetActive(false); // Disable the image if no item is assigned
            quantityText.text = ""; // Clear the quantity text
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (quantity > 0)
        {
            Debug.Log($"Clicked on {item.itemName} with quantity {quantity}");
            // Implement your logic for using or equipping the item here
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                
                if (shopManager == null)
                    // If the shop is open, handle the left-click logic for selling the item
                    Debug.Log($"Left-clicked on {item.itemName} in the inventory.");
                    shopManager.Sellitem(GetComponent<Shop>()); // Call the Sellitem method in the ShopManager script
                    quantity--; // Decrease the quantity of the item in the inventory
                    UpdateUI(); // Update the UI to reflect the changes
                }   

        }
    
    
    }
}
    




