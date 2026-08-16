using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Shop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public itamSO[] itemsForSale; // Array of items available for sale in the shop

    public TMP_Text priceText; // Reference to the TextMeshProUGUI component for displaying prices
    public Image itemImage; // Reference to the Image component for displaying item sprites
    public itamSO itemSO;

    [SerializeField] private SHopManager shopManager; // Reference to the ShopManager script
    [SerializeField] private Shopinfo shopinfo;
    public int[] price; // Array of prices corresponding to the items for sale


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

    public void OnPointerEnter(PointerEventData eventdata)
    {
        if (itemSO != null)
            shopinfo.ShowItemInfo(itemSO);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        shopinfo.Hideiteminfo();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (itemSO != null)
            shopinfo.FollowMouse();
    }
}


