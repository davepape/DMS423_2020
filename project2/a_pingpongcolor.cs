// a_pingpongcolor
// Dave Pape,  20 Sep 2020
// 
// Class to make an object change color smoothly, in a "ping-pong" pattern.
// If this class is attached to a cube positioned to fill the camera view
// (and preferably with an "Unlit/Color" shader), it will cover the full
// screen with the solid color.
//
// [Aside: the "a_" in the class name is just to make file be listed first]
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_pingpongcolor : MonoBehaviour
{
    // Fade the color from red to green
    // back and forth over the defined duration

    public Color colorStart = Color.red;
    public Color colorEnd = Color.green;
    public float duration = 1.0f;
    private Material mat;

    void Start()
        {
        mat = GetComponent<Renderer>().material;
        }

    void Update()
        {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        mat.color = Color.Lerp(colorStart, colorEnd, lerp);
        }
}
