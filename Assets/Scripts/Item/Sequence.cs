using UnityEngine;
using System.Collections.Generic;

public class Sequence : MonoBehaviour
{
    //static = alle Grocken haben den gleichen currenstate
    private static int currentStep;    
    public GameObject tree;


    void Start()
    {
        currentStep = 0;
    }


    // Die richtige Reihenfolge
    public List<string> correctSequence = new List<string>
    {
        "c",
        "g",
        "e",
        "d",
        "g",
        "e",
        "f",
        "a",
        "a",
        "c#",
        "f",
        "a"
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
        Destroy(tree);
        currentStep = 0;
    }

}
