// varyLightColor.cs
// by Dave Pape, 29 Oct 2020
//
// Script to change a light source's color dynamically.
// Two colors can be set in the inspector, and the update will lerp
// back and forth between them.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class varyLightColor : MonoBehaviour
{
    public Color color1 = Color.white;
    public Color color2 = Color.red;
    private Light lightSource;

    void Start()
        {
        lightSource = GetComponent<Light>();
        if (lightSource)
            {
            lightSource.color = color1;
            }
        }

    void Update()
        {
        if (lightSource)
            {
            lightSource.color = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, 1));
            }
        }
}
