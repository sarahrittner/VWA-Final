using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickSpielBeenden : MonoBehaviour, IPointerClickHandler
{
    public AudioSource audioSource;
    public AudioClip click;

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.PlayOneShot(click);
        Debug.Log("Spiel beendet");
        Application.Quit();
    }


    // Update is called once per frame
    void Update()
    {

    }

}