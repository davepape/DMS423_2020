// noiseland.cs
// by Dave Pape, 11 Nov 2020
//
// Creates a fractal landscape using filtered Perlin noise.
// A gridded heightfield mesh is created, based on the code
// of gridmesh.cs, but the elevation of each vertex comes
// from the height() function, which adds up several frequencies
// of Mathf.PerlinNoise().
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noiseland : MonoBehaviour
{
	public int rows=10, cols=10;
	public float minX=-1, maxX=1, minZ=-1, maxZ=1;

    void Start()
    	{
        Vector3[] newVerts;
        newVerts = new Vector3[rows*cols];

        for (int j=0; j < rows; j++)
        	{
	        for (int i=0; i < cols; i++)
	        	{
	        	float x = Mathf.Lerp(minX, maxX, i / (cols-1.0f));
	        	float z = Mathf.Lerp(minZ, maxZ, j / (rows-1.0f));
	        	float y = height(x,z);
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
	
	float height(float x, float y)
	    {
	    x -= minX;
	    y -= minZ;
	    float h = 0;
	    float f = 1, s = 1;
	    for (int i=0; i < 8; i++)
	        {
	        h += s * Mathf.PerlinNoise(f*x, f*y);
	        f *= 2f;
	        s /= 3f;
	        }
	    return h;
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