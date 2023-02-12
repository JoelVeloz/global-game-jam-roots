using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
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
        seed = UnityEngine.Random.Range(-10000, 10000);
        //seed = random.Range(-10000,10000);
        GenerateNoiseTexture();
        GenerarTierra(-100);
        if(Player.transform.position.y % -100 == 0){
            float inicio = Player.transform.position.y - 100f;
            GenerarTierra(inicio);
        }

    }

    public void GenerarTierra(float y){
        int[] numbers = Enumerable.Range(Convert.ToInt32(y), tamanoY + 1).ToArray();
         for (int x = 0 ; x < tamanoX; x++)
        {
            //for(int y = -100 ; y< tamanoY; y++)
            foreach (int i in numbers)
            {
                if (noiseTexture.GetPixel(x,i).r < 0.5f){
                    GameObject newTile = new GameObject(name = "tile");
                    newTile.transform.parent = this.transform;
                    newTile.AddComponent<SpriteRenderer>();
                    newTile.GetComponent<SpriteRenderer>().sprite = tile;
                    newTile.transform.position = new Vector2(x+ 1f,i + 1f); 
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

