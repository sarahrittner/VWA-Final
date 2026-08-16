using UnityEngine;


[CreateAssetMenu(fileName = "New Item")]
public class itamSO : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;

    public bool isGold;
    public bool isMusicSheet;

    [Header("Item Stats")]
    public int itemHealth;
    public int maxHealth;
    public int attackDamage;
    public int speed;

    [Header("For Temporary Items")]
    public float duration; // Duration in seconds for temporary items

}
