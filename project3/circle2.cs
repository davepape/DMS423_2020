// circle2.cs
// by Dave Pape
//
// Move an object in a circle in Unity3d, by "driving"
// Assumes that the object is currently on the edge of a circle, and computes an angle tangent to that circle
// Sets the objects orientation to that angle, and then moves the object "forward" (the "up" vector in this case, since we're working in XY)
// Note that moving forward will actually cause the object to move slightly off of its current circle, and thus spiral away from the origin (this becomes more obvious at higher speeds)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle2 : MonoBehaviour
{

    public float speed=1f;

    void Start ()
        {
        }
	
    void Update ()
        {
        Vector3 pos = transform.localPosition;
        Vector3 dir = new Vector3(-pos[1], pos[0], 0f);
        float angle = Mathf.Atan2(-dir[0], dir[1]) * Mathf.Rad2Deg;
        transform.localEulerAngles = new Vector3(0f, 0f, angle);
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
}
