using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;



public class Wandering1 : MonoBehaviour
{
    [Header("Wander Area")]
    public float wanderwidth;
    public float wanderhight;
    public Vector2 startpos;
    public Rigidbody2D rb;
    public float speed;
    public Vector2 target;
    public float pausedur;
    private bool ispaused;
    public Animator animator;
    public CircleCollider2D circleCollider2D;
    public PlayerController pc;
    private slimecontroller slimecontroller;
    public BoxCollider2D bc;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(startpos, new Vector2(wanderwidth, wanderhight));
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        target = GetRandomTarget();
    }

    private void Update()
    {
        if (ispaused)
        {   
            rb.linearVelocity = Vector2.zero;
            return;
        }
        
        if (Vector2.Distance(transform.position, target) < 0.1f)
            StartCoroutine(PauseandpicknewDestination());



        Vector2 direction = (target - (Vector2)transform.position).normalized;
        rb.linearVelocity = direction * speed;

        if (ispaused)
         {
            animator.SetBool("ismoving", false);
         }
        else
        {
            animator.SetFloat("movex", direction.x);
            animator.SetFloat("movey", direction.y);
            animator.SetBool("ismoving", true);
        }
            
    }

    IEnumerator PauseandpicknewDestination()
    {
        ispaused = true;
        yield return new WaitForSeconds(pausedur);

        target = GetRandomTarget();
        ispaused = false;
    }

    private Vector2 GetRandomTarget()
    {
        float halfwidth = wanderwidth/2;
        float halfheight = wanderhight/2;
        int edge = Random.Range(0,4);
        return edge switch
        {
            0 => new Vector2(startpos.x - halfwidth, Random.Range(startpos.y - halfheight, startpos.y + halfheight)), //left
            1 => new Vector2(startpos.x + halfwidth, Random.Range(startpos.y - halfheight, startpos.y + halfheight)), //right
            2 => new Vector2(Random.Range(startpos.x - halfwidth, startpos.x + halfwidth), startpos.y - halfheight), //bottom
            _ => new Vector2(Random.Range(startpos.x - halfwidth, startpos.x + halfwidth), startpos.y + halfheight), //top
        };

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(PauseandpicknewDestination());
        
    }

    public void OnTriggerEnter2D(CircleCollider2D circleCollider2D)
    {
        if (circleCollider2D.CompareTag("Player"))
        {
            if (target == null)
            {
                target = bc.transform.position;
            }
            
            
            rb.linearVelocity = Vector2.zero;
            slimecontroller.ChangeState(slimecontroller.EnemyState.chase);
        }

    }   
}
