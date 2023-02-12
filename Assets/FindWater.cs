using System.Collections;
using UnityEngine;

public class FindWater : MonoBehaviour
{
    public Transform Target1;
    public Transform Target2;
    public float delay = 0.3f;
    public GameObject prefab;
    public GameObject  verifyRoad;
    private GameObject lastCreatedSquare;
    private Vector2 targetPos;
    private bool isMoving = false;

    



    void Start()
    {
        Target1.position = new Vector2(Mathf.Round(Target1.position.x), Mathf.Round(Target1.position.y));
        Target2.position = new Vector2(Mathf.Round(Target2.position.x), Mathf.Round(Target2.position.y));
        // Al inicio, se almacena la posición inicial del Target 1
        lastCreatedSquare = Instantiate(prefab, Target1.position, Quaternion.identity);
        targetPos = Target2.position;
    }

    void Update()
    {
        // bool existsObject = verifyRoad.GetComponent<isColliding>().isCollidingWithSomething;
        // Debug.Log($"collided  {existsObject}");
        // Debug.Log($"collided  {verifyRoad.GetComponent<isColliding>().isCollidingWithSomething}");
        // Si la posición del Target 2 cambia, se reinicia el camino


       



        Vector2 t2 = Target2.position;
        t2 = new Vector2(Mathf.Round(t2.x), Mathf.Round(t2.y));
        // if (!existsObject)
        // {
             if (t2 != (Vector2)lastCreatedSquare.transform.position)
            {
                targetPos = Target2.position;
                ConstructPath();
                isMoving = true;
            }else{
                // isMoving = true;
            }
        // }
       
      
        verifyRoad.transform.position =  lastCreatedSquare.transform.position; 
        // if (verifyRoad.isTrigger )
        // {
        //    Debug.Log($"collided  "); 
        // }
      
    }
    // void OnTriggerEnter2D(Collider2D col)
    // {
    //     // if (col.GetComponent<Collider>() == verifyRoad.GetComponent<Collider>())
    //     // {
    //     //     Debug.Log("Roca");
    //     // }
    //       Debug.Log($"collided with {col.gameObject.name}");
       
    // }

        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == verifyRoad)
        {
            Debug.Log("El objeto está haciendo trigger a otro objeto");
        }
            Debug.Log("El objeto e12312312tá haciendo trigger a otro objeto");

    }

      void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == verifyRoad)
        {
            Debug.Log("colition");
        }
            Debug.Log("veeerr trigger a otro objeto");
    }


    void ConstructPath()
    {
    //     bool existsObject = ;
        
    //     // Se invoca la función MoveSquare con el delay especificado
    //    if (!verifyRoad.GetComponent<isColliding>().isCollidingWithSomething)
    //    {
         if (!isMoving)
        {
           Invoke("MoveSquare", delay); 
        }
    //    }
        // Invoke("MoveSquare", delay);
    }

    void MoveSquare()
    {

        if (!verifyRoad.GetComponent<isColliding>().isCollidingWithSomething)
        {
             
        // Se obtiene la posición actual del último cuadrado creado
        Vector2 currentSquarePos = lastCreatedSquare.transform.position;

        // Se calcula la dirección que deben moverse los cuadrados para llegar al Target 2
        Vector2 direction = ((Vector2)Target2.position - currentSquarePos).normalized;

        // Se redondea la dirección para asegurar que la posición de cada cuadrado sea una posición entera
        direction.x = Mathf.Round(direction.x);
        direction.y = Mathf.Round(direction.y);

        // Se mueve el último cuadrado creado en la dirección calculada
        // lastCreatedSquare.transform.position = currentSquarePos + direction;
        lastCreatedSquare = Instantiate(prefab,  currentSquarePos + direction, Quaternion.identity);
        }
       

        // Si el último cuadrado no ha llegado al Target 2, se invoca la función MoveSquare con el delay especificado
         Vector2 t2 = Target2.position;
        t2 = new Vector2(Mathf.Round(t2.x), Mathf.Round(t2.y));

                if (t2 != (Vector2)lastCreatedSquare.transform.position )
            {
                // Debug.Log($"collided  ");
                Invoke("MoveSquare", delay);
            }else{
                isMoving = false;
            }
      
    }
}
