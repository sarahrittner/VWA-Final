using UnityEngine;

public class slimecontroller : MonoBehaviour
{

    private Rigidbody2D rb;
    private Transform target;
    public float speed = 3f;
    private bool ischasing;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (ischasing == true)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (target == null)
            {
                target = collision.transform;
            }
            ischasing = true;
        
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ischasing = false;
            rb.linearVelocity = Vector2.zero;
        }

    }
}
