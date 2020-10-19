// triangles.cs
// by Dave Pape, 12 Oct 2020
//
// Create a Unity mesh that consists of 4 points and 2 triangles.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triangles : MonoBehaviour
{
    public Material material;

    void Start()
        {
        if (!(gameObject.GetComponent<MeshFilter>()))
            gameObject.AddComponent<MeshFilter>();
        if (!(gameObject.GetComponent<MeshRenderer>()))
            gameObject.AddComponent<MeshRenderer>();
        GetComponent<Renderer>().material = material;
        Vector3[] newVertices = new Vector3[] { new Vector3(-2, 0, -1),
                                                new Vector3(0, 1, -1),
                                                new Vector3(1, 0, -1),
                                                new Vector3(0, -1, -1) };
        int[] newTriangles = new int[] { 0, 1, 2,  0, 2, 3 };
        Mesh m = GetComponent<MeshFilter>().mesh;
        m.Clear();
        m.vertices = newVertices;
        m.triangles = newTriangles;
        m.RecalculateNormals();
        }
}
