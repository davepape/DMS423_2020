using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class gpw : MonoBehaviour
{
	public float max=100000f;

    private int IntHeaderVal(string s)
        {
        string[] tokens = s.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
        return int.Parse(tokens[1]);
        }

    private float FloatHeaderVal(string s)
        {
        string[] tokens = s.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
        return float.Parse(tokens[1]);
        }

    private Texture2D InitTexture(int width, int height)
        {
	    Texture2D texture = new Texture2D(width,height);
	    var initColors = new Color32[width*height];
	    for (int i=0; i < width*height; i++)
	        initColors[i] = Color.black;
	    texture.SetPixels32(initColors,0);
	    GetComponent<Renderer>().material.mainTexture = texture;
	    return texture;
        }

    private Color TransferFunction(float data)
        {
        Color color;
        if (data > max)
        	color = Color.white;
        else if (data >= 0)
        	// This produces a classic (though not ideal) "heatmap" color scale, going from 0->blue to max->red
            color = Color.HSVToRGB((1f-data/max)*0.667f,1,1);
	    else
		    color = Color.black;
		return color;
        }
        
    void Start()
        {
	    string[] lines = System.IO.File.ReadAllLines("Assets/glp00g15.asc");
	    int ncols = IntHeaderVal(lines[0]);
	    int nrows = IntHeaderVal(lines[1]);
	    float xllcorner = FloatHeaderVal(lines[2]);
	    float yllcorner = FloatHeaderVal(lines[3]);    
	    float cellsize = FloatHeaderVal(lines[4]);    
        int width = (int)(360.0f/cellsize);
        int height = (int)(180.0f/cellsize);
   	    Texture2D texture = InitTexture(width,height);
	    
     	for (int i=0; i < nrows; i++)
            {
            int texRow = (nrows-1)-i + (int)((90+yllcorner)/cellsize);
            string[] vals = lines[i+6].Split(' ');
            for (int j=0; j < ncols; j++)
            	{
            	int texCol = j+(int)((180+xllcorner)/cellsize);
	            float pop = float.Parse(vals[j]);
			    texture.SetPixel(texCol, texRow, TransferFunction(pop));
	            }
            }
	
	    texture.Apply();
        }

}
