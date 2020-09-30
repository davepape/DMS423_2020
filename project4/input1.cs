using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input1 : MonoBehaviour
{
    private Material mat;

    void Start()
    {
    mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
    if (Input.GetButton("Fire1"))
        mat.color = Color.red;
    else
        mat.color = Color.green;
    }
}
