using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionTierra : MonoBehaviour
{
    public Sprite tile;
    public int tamanoX = 100;
    public int tamanoY = 100;
    public float noiseFreq = 0.05f;
    public float seed;
    public Texture2D noiseTexture;
    //public List<GameObject> worldtiles = new List<GameObject>;
    public GameObject Player;

    private void Start()
    {
        seed = Random.Range(-10000,10000);
        GenerateNoiseTexture();
        GenerarTierra();

    }

    public void GenerarTierra(){
        
         for (int x = 0 ; x < tamanoX; x++)
        {
            for(int y = 0 ; y< tamanoY; y++)
            {
                if (noiseTexture.GetPixel(x,y).r < 0.5f){
                    GameObject newTile = new GameObject(name = "tile");
                    newTile.transform.parent = this.transform;
                    newTile.AddComponent<SpriteRenderer>();
                    newTile.GetComponent<SpriteRenderer>().sprite = tile;
                    newTile.transform.position = new Vector2(x+ 1f,y + 1f); 
                }
            }


            }
        }
    

    public void GenerateNoiseTexture(){
        noiseTexture = new Texture2D(tamanoX,tamanoY);

        for (int x = 0; x < noiseTexture.width; x++)
        {
            for(int y = 0; y< noiseTexture.height; y++)
            {
                float v = Mathf.PerlinNoise((x + seed)*noiseFreq,(y + seed)*noiseFreq);
                noiseTexture.SetPixel(x, y, new Color(v,v,v));
            }
        }
    
        noiseTexture.Apply();
    }
    
}

