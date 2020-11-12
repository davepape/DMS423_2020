// noisetex.cs
// by Dave Pape, 11 Nov 2020
//
// Creates a procedural texture, where each texel has a grey color
// based on filtered Perlin noise.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noisetex : MonoBehaviour
{
    public int width=256;
    public int height=256;
    private Texture2D tex;
    private Color32[] colors;

    void Start ()
        {
        tex = new Texture2D(width,height);
        colors = new Color32[width*height];
        GetComponent<Renderer>().material.mainTexture = tex;
        generateTexture(0);
        }

    void Update ()
        {
        if (Time.frameCount % 100 == 0)
            print(1f/Time.deltaTime + " fps");
        generateTexture(Time.time/10f);
        }

    void generateTexture(float offset)
        {
        int index=0;
        for (int j = 0; j < height; j++)
            {
            for (int i=0; i < width; i++)
                {
                float v = value(i/(width-1f)+offset,j/(height-1f));
                colors[index] = new Color(v,v,v,1);
                index++;
                }
            }
        tex.SetPixels32(colors);
        tex.Apply();
        }

    float value(float x, float y)
        {
        float v = 0;
        float f = 8, s = 0.75f;
        for (int i=0; i < 4; i++)
            {
            v += s * Mathf.PerlinNoise(f*x, f*y);
            f *= 2f;
            s /= 3f;
            }
        return v;
        }

}