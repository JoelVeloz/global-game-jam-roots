using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isColliding : MonoBehaviour
{
    public bool isCollidingWithSomething = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        isCollidingWithSomething = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        isCollidingWithSomething = false;
    }
    
    //  void OnTrigger2D(Collider2D col)
    // {
    //     Debug.Log($"TRIGEEEEEEEEEEEEEEEEEEEEEEEEEER");
       
    // }
    //  void OnCollisionEnter2D(Collision2D collision)
    // {
    //         Debug.Log($"collided wit22h ");
    // }
}
