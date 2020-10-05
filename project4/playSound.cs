// playSound
// by Dave Pape, 5 Oct 2020
//
// Minimal example of playing a sound in Unity.  This script should be
// attached to an object that has an AudioSource component (a sound file).
// It gets the component, and calls the Play() method when needed.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    private AudioSource soundeffect;

    void Start()
    {
    soundeffect = GetComponent<AudioSource>();
    }

    void Update()
    {
    if (Input.GetButtonDown("Fire1"))
        {
        soundeffect.Play();
        }
    }
}
