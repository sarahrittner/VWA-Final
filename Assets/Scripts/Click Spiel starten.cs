using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MouseclickHauptmenü : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Spiel gestartet");
        SceneManager.LoadScene("MainScene");
    }


    // Update is called once per frame
    void Update()
    {

    }

}