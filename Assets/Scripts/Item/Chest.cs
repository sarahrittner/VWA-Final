
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Chest : MonoBehaviour
{
    public Animator animator;
    public float timer = 0.8f;
    public GameObject Schwert;
    public Vector2 pos;
    public Quaternion rotation;
    public GameObject Chestt;

    private void Start()
    {
        pos = transform.position;
        rotation = transform.rotation;
    }
    public void Interactc()
    {
        animator.Play("open");
        StartCoroutine(Warten());



    }
    
    IEnumerator Warten()
    {
        yield return new WaitForSeconds(timer);

        Instantiate(Schwert, pos, rotation);
        Destroy(Chestt);

    }
}
