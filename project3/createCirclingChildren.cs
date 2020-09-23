// createCirclingChildren.cs
// by Dave Pape
//
// Unity3d script to animate many circling objects
// Script creates the objects on startup, by instantiating a given object (create a prefab and assign it to the "obj" parameter in the inspector)
// Then moves them in a circle in the same way as circleChildren.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createCirclingChildren : MonoBehaviour
{

    public int numberOfChildren = 1;
    public Object obj;
    public float speed = 1f;
    public float radius = 1f;

    void Start ()
        {
        for (int i=0; i < numberOfChildren; i++)
            Instantiate(obj, transform);
        }
    
    void Update ()
        {
        for (int i=0; i < transform.childCount; i++)
            {
            Transform child = transform.GetChild(i);
            float angle = Time.time * speed + 2f*Mathf.PI*i/transform.childCount;
            child.localPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * radius;
            }        
        }
}
