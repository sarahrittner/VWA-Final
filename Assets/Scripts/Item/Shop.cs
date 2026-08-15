using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public itamSO[] itemsForSale; // Array of items available for sale in the shop

    public TMP_Text priceText; // Reference to the TextMeshProUGUI component for displaying prices
    public Image itemImage; // Reference to the Image component for displaying item sprites


    [SerializeField] private SHopManager shopManager; // Reference to the ShopManager script
    private int[] price; // Array of prices corresponding to the items for sale


    public void Initialize(itamSO[] items, int[] prices)
    {
        // Implement your logic to initialize the shop, such as populating items for sale
        itemsForSale = items;
        itemImage.sprite = items[0].itemSprite; // Display the first item's sprite
        this.price = prices;
        priceText.text = prices[0].ToString() + " Gold"; // Display the first item's price
    }

    public void BuyOnButtonClicked()
    {
        shopManager.TryBuyItem(itemsForSale[0], price[0]); // Call the BuyItem method in the ShopManager script
    }
    
    
}
