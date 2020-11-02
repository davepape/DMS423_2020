// trianglesWithTexture.cs
// by Dave Pape, 1 Nov 2020
//
// New version of triangles.cs, which adds UV coordinates so that a texture
// can be applied to the object.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trianglesWithTexture : MonoBehaviour
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
        Vector2[] newUV = new Vector2[] { new Vector2(0, 0.5f),
                                          new Vector2(0.5f, 1),
                                          new Vector2(1, 0.5f),
                                          new Vector2(0.5f, 0) };
        int[] newTriangles = new int[] { 0, 1, 2,  0, 2, 3 };
        Mesh m = GetComponent<MeshFilter>().mesh;
        m.Clear();
        m.vertices = newVertices;
        m.uv = newUV;
        m.triangles = newTriangles;
        m.RecalculateNormals();
        }
}
