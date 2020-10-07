// AABB
// by Dave Pape, 6 Oct 2020
//
// Demonstration of an axis-aligned bounding box.  The code takes values for minimum & maximum X
// and minimum & maximum Y, and creates a Unity Rect using that data.
// It then constructs a cube primitive that covers that box's area, and changes the color of
// the cube based on whether the mouse is inside or outside the box.
// !! Note that the code assumes the camera is using an orthographic projection.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABB : MonoBehaviour
{
    public float xMin=0f, xMax=1f, yMin=0f, yMax=1f;
    private GameObject cube;
    private Rect myrect;
    private Camera cam;

    void Start()
    {
    myrect = Rect.MinMaxRect(xMin,yMin,xMax,yMax);
    makeBox(myrect);
    cam = Camera.main;
    }

    void makeBox(Rect r)
    {
    cube = GameObject.CreatePrimitive(PrimitiveType.Cube); 
    cube.transform.localScale = new Vector3(r.width, r.height, 1f);
    cube.transform.localPosition = new Vector3(r.xMin+r.width/2f, r.yMin+r.height/2f, 0);
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
    if (myrect.Contains(new Vector2(x,y)))
        cube.GetComponent<Renderer>().material.color = Color.red;
    else
        cube.GetComponent<Renderer>().material.color = Color.green;
    }
}
