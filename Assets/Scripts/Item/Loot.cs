using UnityEngine;

public class Loot : MonoBehaviour
{
    public itamSO item; // Reference to the item scriptable object
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    public Animator animator; // Reference to the Animator component
    public int quantity; // Quantity of the item

    private void OnValidate()
    {
        // Update the sprite in the editor when the item is assigned
        if (item != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = item.itemSprite;
            this.name = item.itemName; // Update the GameObject's name to match the item name
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.Play("pickup");

            // Destroy the loot object after pickup
            Destroy(gameObject, 0.5f);
        }
    }
}
