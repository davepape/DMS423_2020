// mydata.cs
// by Dave Pape, 8 Oct 2020
//
// A script with some data - variable "value" - that changes when the user hits
// a fire button.  The purpose of this is to work with "observer.cs", to
// demonstrate how one script can access another's variables.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mydata : MonoBehaviour
{
    public float value=0;

    void Start()
    {
    }

    void Update()
    {
    if (Input.GetButton("Fire1"))
        {
        value += Time.deltaTime * 3000;
        transform.localScale = new Vector3(2f,2f,2f);
        }
    else if (Input.GetButton("Fire2"))
        {
        value -= Time.deltaTime * 3000;
        transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        }
    else
        transform.localScale = new Vector3(1f,1f,1f);
    }
}
