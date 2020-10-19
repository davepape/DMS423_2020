// trianglesWithColors.cs
// by Dave Pape, 12 Oct 2020
//
// A variation of triangles.cs, which adds RGB color data.  The colors
// must be defined per-vertex - ie for each vertex (XYZ location), there
// is a corresponding color value; these are defined by two parallel arrays.
// This example requires the file "vertexColor.shader" to be in your
// project's assets.  The custom shader uses the per-vertex color data
// instead of any lighting or texturing.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trianglesWithColors : MonoBehaviour
{
    void Start()
        {
        if (!(gameObject.GetComponent<MeshFilter>()))
            gameObject.AddComponent<MeshFilter>();
        if (!(gameObject.GetComponent<MeshRenderer>()))
            gameObject.AddComponent<MeshRenderer>();
        GetComponent<Renderer>().material = new Material(Shader.Find("Custom/Vertex Colored"));
        Vector3[] newVertices = new Vector3[] { new Vector3(-2f, 0f, -1f),
                                                new Vector3(0f, 1f, -1f),
                                                new Vector3(1f, 0f, -1f),
                                                new Vector3(0f, -1f, -1f) };
        Color[] newColors = new Color[] { Color.red,
                                        Color.green,
                                        Color.blue,
                                        Color.yellow };
        int[] newTriangles = new int[] { 0, 1, 2,   0, 2, 3 };
        Mesh m = GetComponent<MeshFilter>().mesh;
        m.Clear();
        m.vertices = newVertices;
        m.colors = newColors;
        m.triangles = newTriangles;
        }
}
