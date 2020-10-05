// playSound2
// by Dave Pape, 5 Oct 2020
//
// Minimal example of changing the volume of a sound.
// Should be attached to an object that has an AudioSource component.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound2 : MonoBehaviour
{
    private AudioSource soundeffect;

    void Start()
    {
// Find the AudioSource and start it playing in an infinite loop
    soundeffect = GetComponent<AudioSource>();
    soundeffect.loop = true;
    soundeffect.Play();
    }

    void Update()
    {
// Change the volume (loudness) based on the input.
// (Note that a negative value will be the same as 0 volume.)
    soundeffect.volume = Input.GetAxis("Vertical");

// Change the object's scale just for some visual feedback; does not affect sound
    transform.localScale = new Vector3(1f,1f,1f) * Input.GetAxis("Vertical");
    }
}
