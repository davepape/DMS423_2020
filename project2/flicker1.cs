// flicker1
// Dave Pape,  20 Sep 2020
// 
// Extension of "a_pingpongcolor" example, to make the object flicker on
// alternating frames between black and the color that is being interpolated
//
// It uses a flag "is_on" to determine which state the object is in.  The value
// is switched on each update (i.e. every frame).
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker1 : MonoBehaviour
{
    public Color colorStart = Color.red;
    public Color colorEnd = Color.green;
    public float duration = 1.0f;
    private Material mat;
    private bool is_on = true;

    void Start()
    	{
        mat = GetComponent<Renderer>().material;
    	}

    void Update()
    	{
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        if (is_on)
        	{
	        mat.color = Color.Lerp(colorStart, colorEnd, lerp);
	        is_on = false;
        	}
        else
        	{
	        mat.color = Color.black;
	        is_on = true;
        	}
    	}
}
