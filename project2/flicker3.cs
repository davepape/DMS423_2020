// flicker3
// Dave Pape,  20 Sep 2020
// 
// Extension of "flicker2".  This example adds an array of colors as
// simple keyframes to step through.  It starts by transitioning from
// "colors[0]" to "colors[1]" over "duration" seconds; when that time
// has finished, the "curColor" variable increases to start transitioning
// to the next color in the array.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker3 : MonoBehaviour
{
    public Color[] colors = { Color.red, Color.green };
    public float duration = 1.0f;
    private int curColor = 0;
    private float colorStartTime;
    private Material mat;
    public float flickerTime = 1.0f; // change every 1.0 seconds
    private float lastFlickerTime;
    private bool is_on = true;

    void Start()
        {
        mat = GetComponent<Renderer>().material;
        colorStartTime = Time.time;
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
            float lerp = (Time.time - colorStartTime) / duration;
            int c1 = curColor;
            int c2 = (curColor+1) % colors.Length;
            mat.color = Color.Lerp(colors[c1], colors[c2], lerp);
            if (lerp >= 1.0f)
                {
                curColor = (curColor + 1) % colors.Length;
                colorStartTime = Time.time;
                }
            }
        else
            {
            mat.color = Color.black;
            }
        }
}
