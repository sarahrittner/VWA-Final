using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;


public class Inventoryslots : MonoBehaviour, IPointerClickHandler
{
    public itamSO item; // Reference to the item scriptable object
    public int quantity; // Quantity of the item
    public Image image; // Reference to the Image component for displaying the item sprite
    public TMP_Text quantityText; // Reference to the TextMeshProUGUI component for displaying the quantity
    public InventoryManager inventoryManager; // Reference to the InventoryManager script

    private void Start()
    {
        inventoryManager = GetComponentInParent<InventoryManager>();
    }

    public void UpdateUI()
    {


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
        if (item != null)
        {
            Debug.Log($"Clicked on {item.itemName} with quantity {quantity}");
            // Implement your logic for using or equipping the item here
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                // Right-click logic (e.g., use or equip the item)
                Debug.Log($"Right-clicked on {item.itemName}");
                // Example: Use the item
                inventoryManager.UseItem(this);
            }
        }
    }
    



}
