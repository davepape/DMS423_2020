// circleOther.cs
// by Dave Pape
//
// Unity script to make an object move in a circle.
// In this case, instead of moving the object that runs the script, we have
// it move another object.  A reference to the other object is obtained
// using GameObject.Find()
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleOther : MonoBehaviour
{
    public float speed = 1f;
    public float radius = 1f;

    void Start()
        {
        }

    void Update()
        {
        GameObject thecube = GameObject.Find("Cube");
        float angle = Time.time * speed;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        thecube.transform.localPosition = new Vector3(x, y, 0f);
        }
}
