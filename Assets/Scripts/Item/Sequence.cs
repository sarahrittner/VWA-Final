using UnityEngine;
using System.Collections.Generic;

public class Sequence : MonoBehaviour
{

    private int currentStep;    

    void Start()
    {
        currentStep = 0;
    }


    // Die richtige Reihenfolge
    public List<string> correctSequence = new List<string>
    {
        "Left",
        "Right",
        "Middle"
    };




    public void PressButton(string buttonName)
    {
        // Ist es der richtige Knopf?
        if (buttonName == correctSequence[currentStep])
        {
            currentStep++;

            Debug.Log("Richtig! Schritt " + currentStep);

            // Ganze Kombination geschafft?
            if (currentStep >= correctSequence.Count)
            {
                OpenDoor();
            }
        }
        else
        {
            Debug.Log("Falscher Knopf! Zurück auf Anfang.");
            currentStep = 0;
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Tür öffnet sich!");

        // Hier später Türanimation etc.
    }

}
