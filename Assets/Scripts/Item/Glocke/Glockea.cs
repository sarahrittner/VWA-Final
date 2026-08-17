using UnityEngine;

public class Glockea : MonoBehaviour
{

    public Sequence sequence; // Reference to the Sequence script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interactg()
    {
        Debug.Log("Interacted with Glocke.");
        // Add your interaction logic here

        if (sequence == null)
        {
            Debug.LogError("SEQUENCE IST NULL!");
            return;
        }
        sequence.PressButton("a");
        Debug.Log("Pressed button a");
        
    
    }
}
