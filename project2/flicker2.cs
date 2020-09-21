// flicker2
// Dave Pape,  20 Sep 2020
// 
// Extension of "flicker1" example.  In this version, the variable
// "flickerTime" specifies how quickly the flickering should happen.
// "lastFlickerTime" records the last time the state was switched;
// when the amount of time that has passed since then exceeds "flickerTime",
// the state changes.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker2 : MonoBehaviour
{
    public Color colorStart = Color.red;
    public Color colorEnd = Color.green;
    public float duration = 1.0f;
    private Material mat;
    public float flickerTime = 1.0f; // change every 1.0 seconds
    private float lastFlickerTime;
    private bool is_on = true;

    void Start()
    	{
        mat = GetComponent<Renderer>().material;
        lastFlickerTime = Time.time;
    	}

    void Update()
	    {
        if (Time.time - lastFlickerTime >= flickerTime)
        	{
        	is_on = ! is_on;
        	lastFlickerTime = Time.time;
        	}

        if (is_on)
        	{
        	float lerp = Mathf.PingPong(Time.time, duration) / duration;
	        mat.color = Color.Lerp(colorStart, colorEnd, lerp);
	       	}
        else
        	{
	        mat.color = Color.black;
        	}
    	}
}
