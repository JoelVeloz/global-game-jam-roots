using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugController : MonoBehaviour
{
    public bool controlEnabled = true;
    public int speed;
    private bool moveRight;

    private Animator animator;

    private GameObject player;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlEnabled)
        {
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }

        if (transform.position.y < -30)
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision");
        if(collision.CompareTag("Player"))
        {
            GetComponent<Collider2D>().isTrigger = true;
            controlEnabled=false;
            animator.SetBool("Death", true);
            Invoke("Death",0.6f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (moveRight)
                Flip();
            else
                Flip();
        }
    }

    public void Death()
    {
            //animator.SetBool("Death", true);
            Destroy(gameObject);
            
        
    }

   

    private void Flip()
    {
        moveRight = !moveRight;
        Vector2 ls = gameObject.transform.localScale;
        ls.x *= -1;
        transform.localScale = ls;
    }

}
