// createCirclingArray.cs
// by Dave Pape, 21 Oct 2020
//
// This is a variation of createCirclingChildren.cs
// Instead of using Unity's scene hierarchy to keep track of the instantiated
// objects, it keeps the list of objects in an array.
// This is intended to demonstrate the basics of allocating & filling an
// array in C#.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createCirclingArray : MonoBehaviour
{

    public int numberOfChildren = 1;
    public Object obj;
    public float speed = 1f;
    public float radius = 1f;
    private GameObject[] children;

    void Start ()
        {
        children = new GameObject[numberOfChildren];
        for (int i=0; i < numberOfChildren; i++)
            children[i] = (GameObject) Instantiate(obj);
        }
    
    void Update ()
        {
        for (int i=0; i < children.Length; i++)
            {
            Transform child = children[i].transform;
            float angle = Time.time * speed + 2f*Mathf.PI*i/children.Length;
            child.localPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * radius;
            }        
        }
}
