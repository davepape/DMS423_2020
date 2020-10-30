// onoff.cs
// by Dave Pape, 29 Oct 2020
//
// A script that toggles all its children between 'active' and 'not active',
// whenever the Fire1 button is pressed.
// This is intended to show how a light can be turned on & off, but applies in
// any situation where you want to activate/deactivate objects.  The important
// detail is that a GameObject can't really use SetActive() on itself, because
// once it's inactive, its script will not be running to re-activate it.
// Hence, objects that must be toggled should be attached as children of the
// object that runs this script.  The concept can also be used without parenting,
// as long as you have a reference to the objects that will be toggled.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onoff : MonoBehaviour
{
    public bool state = true;

    void Start()
        {
        for (int i=0; i < transform.childCount; i++)
            {
            transform.GetChild(i).gameObject.SetActive(state);
            }
        }

    void Update()
        {
        if (Input.GetButtonDown("Fire1"))
            {
            state = !state;
            for (int i=0; i < transform.childCount; i++)
                {
                transform.GetChild(i).gameObject.SetActive(state);
                }
            }
        }
}
