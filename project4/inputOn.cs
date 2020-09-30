using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputOn : MonoBehaviour
{
    private Material mat;

    void Start()
    {
    mat = GetComponent<Renderer>().material;
    }

    void OnMouseDown()
    {
    mat.color = Color.red;
    }

    void OnMouseUp()
    {
    mat.color = Color.green;
    }

}
