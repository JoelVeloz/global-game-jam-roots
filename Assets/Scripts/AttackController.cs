using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision_Feet");
        if(collision.CompareTag("Player"))
        {
            GetComponent<Collider2D>().isTrigger = true;
            //GetComponentInParent<SlugController>().Death();
        }
    }
}
