// dynamicTriangles.cs
// by Dave Pape, 12 Oct 2020
//
// Variation of triangles.cs that changes the vertex data every frame.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicTriangles : MonoBehaviour
{
    public Material material;
    private Vector3[] myVertices;

    void Start()
        {
        if (!(gameObject.GetComponent<MeshFilter>()))
            gameObject.AddComponent<MeshFilter>();
        if (!(gameObject.GetComponent<MeshRenderer>()))
            gameObject.AddComponent<MeshRenderer>();
        GetComponent<Renderer>().material = material;
        myVertices = new Vector3[] { new Vector3(-2f, 0f, -1f),
                                                new Vector3(0f, 1f, -1f),
                                                new Vector3(1f, 0f, -1f),
                                                new Vector3(0f, -1f, -1f) };
        int[] newTriangles = new int[] { 0, 1, 2,  0, 2, 3 };
        Mesh m = GetComponent<MeshFilter>().mesh;
        m.Clear();
        m.vertices = myVertices;
        m.triangles = newTriangles;
        m.RecalculateNormals();
        }
    
    void Update()
        {
        Mesh m = GetComponent<MeshFilter>().mesh;
        myVertices[2].x = Mathf.Sin(Time.time) + 1;
        m.vertices = myVertices;
        }
}
