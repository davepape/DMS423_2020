// gridmesh.cs
// by Dave Pape, 4 Nov 2020
//
// Script to generate a Unity mesh of triangles that form
// a simple grid.  This will be used as the basis of a
// future example of fractal terrain.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridmesh : MonoBehaviour
{
	public int rows=4, cols=4;
	public float minX=0, maxX=1, minY=0, maxY=1;

    void Start()
    {
        Vector3[] newVerts;
        newVerts = new Vector3[rows*cols];

        for (int j=0; j < rows; j++)
        	{
	        for (int i=0; i < cols; i++)
	        	{
	        	float a = i / (cols-1.0f);
	        	float x = Mathf.Lerp(minX, maxX, a);
	        	a = j / (rows-1.0f);
	        	float y = Mathf.Lerp(minY, maxY, a);
	        	float z = Random.value;
	        	newVerts[j*cols+i] = new Vector3(x,y,z);
	        	}
        	}

        Vector2[] newUVs = new Vector2[rows*cols];
        for (int j=0; j < rows; j++)
        	{
	        for (int i=0; i < cols; i++)
	        	{
	        	float u = i / (cols-1.0f);
	        	float v = j / (rows-1.0f);
	        	newUVs[j*cols+i] = new Vector2(u,v);
	        	}
        	}

        int[] newTris = new int[(cols-1)*(rows-1)*2*3];
        int index=0;
        for (int j=0; j < rows-1; j++)
        	{
	        for (int i=0; i < cols-1; i++)
	        	{
	        	newTris[index++] = j*cols+i;
	        	newTris[index++] = j*cols+i + cols;
	         	newTris[index++] = j*cols+i + 1;

	        	newTris[index++] = j*cols+i + cols;
	        	newTris[index++] = j*cols+i + cols+1;
	         	newTris[index++] = j*cols+i + 1;
	        	}
        	}

        Mesh m = GetComponent<MeshFilter>().mesh;
        m.Clear();
        m.vertices = newVerts;
        m.uv = newUVs;
        m.triangles = newTris;
 		m.RecalculateNormals();
     }

    void Update()
    {
        
    }

    void OnDrawGizmos()
        {
        Mesh m = GetComponent<MeshFilter>().sharedMesh;
        if ((m) && (m.vertices.Length > 0))
            {
            Gizmos.matrix = transform.localToWorldMatrix; 
            for (int i=0; i < m.vertices.Length; i++)
                Gizmos.DrawSphere(m.vertices[i], 0.05f);
            Gizmos.DrawWireMesh(m);
            }
        }
}