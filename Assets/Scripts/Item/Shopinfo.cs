using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class Shopinfo : MonoBehaviour
{
    public CanvasGroup infopanel;
    public TMP_Text itemnametext;
    public TMP_Text iteminfotext;

    private RectTransform infopanelrect;

    private void Awake()
    {
        infopanelrect = GetComponent<RectTransform>();

    }

    public void ShowItemInfo(itamSO itemSO)
    {
        infopanel.alpha = 1;

        itemnametext.text = itemSO.itemName;
        iteminfotext.text = itemSO.itemDescription;
    }

    public void Hideiteminfo()
    {
        infopanel.alpha = 0;
        itemnametext.text = "";
        iteminfotext.text = "";

    }

    public void FollowMouse()
    {
        Vector2 mousepos = Input.mousePosition;
        Vector2 offset = new Vector2 (80, -80);

        infopanelrect.position = mousepos + offset;

    }



}
