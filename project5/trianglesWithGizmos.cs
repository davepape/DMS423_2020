// trianglesWithGizmos.cs
// by Dave Pape, 12 Oct 2020
//
// Create a Unity mesh that consists of 4 points and 2 triangles.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trianglesWithGizmos : MonoBehaviour
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
        myVertices = new Vector3[] { new Vector3(-2, 0, -1),
                                     new Vector3(0, 1, -1),
                                     new Vector3(1, 0, -1),
                                     new Vector3(0, -1, -1) };
        int[] newTriangles = new int[] { 0, 1, 2,  0, 2, 3 };
        Mesh m = GetComponent<MeshFilter>().mesh;
        m.Clear();
        m.vertices = myVertices;
        m.triangles = newTriangles;
        m.RecalculateNormals();
        }

    void OnDrawGizmos()
        {
        if (myVertices != null)
            {
            Gizmos.matrix = transform.localToWorldMatrix; 
            for (int i=0; i < myVertices.Length; i++)
                Gizmos.DrawSphere(myVertices[i], 0.05f);
            Gizmos.DrawWireMesh(GetComponent<MeshFilter>().mesh);
            }
        }
}
