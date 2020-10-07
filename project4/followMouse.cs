// followMouse
// by Dave Pape, 6 Oct 2020
//
// Code to move an object so that it is attached to the mouse, assuming that
// the camera is using an Orthographic projection.
// This gets the current mouse position (in pixel coordinates, measured from the
// lower left corner), and converts them to world coordinates based on the camera
// projection & transformation data.
// (Note: this is not intended to show the best way to move an object with the
// mouse in Unity; it's strictly for understanding the orthographic projection
// and the mouse input's coordinate systems.)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
    cam = Camera.main;
    }

    void Update()
    {
    float ysize = cam.orthographicSize;
    float xsize = ysize * cam.aspect;
    float minx = cam.gameObject.transform.localPosition.x - xsize;
    float maxx = cam.gameObject.transform.localPosition.x + xsize;
    float miny = cam.gameObject.transform.localPosition.y - ysize;
    float maxy = cam.gameObject.transform.localPosition.y + ysize;
    float x = Mathf.Lerp(minx,maxx,(Input.mousePosition.x / Screen.width));
    float y = Mathf.Lerp(miny,maxy,(Input.mousePosition.y / Screen.height));
    transform.localPosition = new Vector3(x,y,0f);
    }
}
