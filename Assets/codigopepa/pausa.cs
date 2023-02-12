using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausa : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPause = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MenuP(){
        if(isPause) {
            isPause = !isPause;
            Time.timeScale = 0f;
        }else{
              isPause = !isPause;
 Time.timeScale = 1f;
        }
       

    }
}
