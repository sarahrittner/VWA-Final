using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Endend : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Warten());
    }

    IEnumerator Warten()
    {
    Debug.Log("Warten beginnt");

    yield return new WaitForSeconds(11f);

    SceneManager.LoadScene("HAuptmenü");
    }
}
