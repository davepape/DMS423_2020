// circle1.cs
// by Dave Pape
//
// Minimal Unity3d example of moving an object in a circle
// Script determines a current angle, then computes an X & Y for that angle using cos & sin
// Object is placed at the computed X,Y by setting the "localPosition" attribute of its transform
// Script uses 2 public variables so that you can control the size of the circle and how fast it moves
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle1 : MonoBehaviour
{
    public float radius = 5f;
    public float speed = 1f;

    void Start ()
        {
        }
	
    void Update ()
        {
        float angle = Time.time * speed;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        transform.localPosition = new Vector3(x, y, 0f);
        }
}
