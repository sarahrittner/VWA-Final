using UnityEngine;

public class useItem : MonoBehaviour
{
    public void ApplyItemEffect(itamSO item)
    {
        if (item.itemHealth > 0)
        {
            // Assuming you have a reference to the player's health script
            PlayerController playerHealth = FindFirstObjectByType<PlayerController>();
            if (playerHealth != null)
            {
                playerHealth.currentHealth += item.itemHealth;
                if (playerHealth.currentHealth > playerHealth.maxHealth)
                {
                    playerHealth.currentHealth = playerHealth.maxHealth; // Cap health at max
                }
            }
            
            
        }

        // Add more conditions for other item effects as needed
    }
}
