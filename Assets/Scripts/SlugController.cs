using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugController : MonoBehaviour
{
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

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (moveRight)
                Flip();
            else
                Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            animator.SetBool("Death", true);
            GetComponent<Collider2D>().isTrigger = true;

            float countdown = 0.5f;
            countdown -= Time.deltaTime;
            if(countdown > 0f)
            {
                rb.velocity = new Vector2(1f, 5f);
            }
        }
    }

    private void Flip()
    {
        moveRight = !moveRight;
        Vector2 ls = gameObject.transform.localScale;
        ls.x *= -1;
        transform.localScale = ls;
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
