using NUnit.Framework;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    private bool isShopOpen;



    public void Interacts()
    {
        Debug.Log("shopkeeper");
        if (!isShopOpen)
        {
            Time.timeScale = 0;
            isShopOpen = true;
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }
        else
        {
            Time.timeScale = 1;
            isShopOpen = false;
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }
    }
}
