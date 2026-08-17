using UnityEngine;

public class Glocker : MonoBehaviour
{

    public Sequence sequence; // Reference to the Sequence script


    public void Interactg()
    {
        Debug.Log("Interacted with Glocke.");
        // Add your interaction logic here

        if (sequence == null)
        {
            Debug.LogError("SEQUENCE IST NULL!");
            return;
        }
        sequence.PressButton("c#");
        Debug.Log("Pressed button c#");
        
    
    }
}
