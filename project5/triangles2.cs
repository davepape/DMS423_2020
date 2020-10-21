// triangles2.cs
// by Dave Pape, 21 Oct 2020
//
// Create a Unity mesh of some number of triangles.
// This is intended primarily to demonstrate allocating and filling in
// arbitrary-sized arrays in C#.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triangles2 : MonoBehaviour
{
    public int numTriangles = 3;
    public Material material;

    void Start()
        {
        if (!(gameObject.GetComponent<MeshFilter>()))
            gameObject.AddComponent<MeshFilter>();
        if (!(gameObject.GetComponent<MeshRenderer>()))
            gameObject.AddComponent<MeshRenderer>();
        GetComponent<Renderer>().material = material;

        Vector3[] newVertices = new Vector3[numTriangles * 3];
        for (int i=0; i < numTriangles; i++)
            {
            newVertices[i*3] = new Vector3(i,0,0);
            newVertices[i*3+1] = new Vector3(i+0.5f, 1, 0);
            newVertices[i*3+2] = new Vector3(i+1,0,0);
            }
        int[] newTriangles = new int[numTriangles * 3];
        for (int i=0; i < numTriangles; i++)
            {
            newTriangles[i*3] = i*3;
            newTriangles[i*3+1] = i*3+1;
            newTriangles[i*3+2] = i*3+2;
            }

        Mesh m = GetComponent<MeshFilter>().mesh;
        m.Clear();
        m.vertices = newVertices;
        m.triangles = newTriangles;
        m.RecalculateNormals();
        }
}
