// varyLight.cs
// by Dave Pape, 29 Oct 2020
//
// Script to vary the intensity of a light source.
// The light will start at its intensity as set in the Unity inspector,
// and then vary (in a sine wave) between 0 and double that.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class varyLight : MonoBehaviour
{
    private Light lightSource;
    private float startIntensity;

    void Start()
        {
        lightSource = GetComponent<Light>();
        if (lightSource)
            {
            startIntensity = lightSource.intensity;
            }
        }

    void Update()
        {
        if (lightSource)
            {
            lightSource.intensity = startIntensity * (Mathf.Sin(Time.time) + 1);
            }
        }
}
