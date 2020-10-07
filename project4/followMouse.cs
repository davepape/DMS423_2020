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
