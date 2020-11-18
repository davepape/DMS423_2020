/*
 Create Unity mesh data for a sphere, which can be used with a video (or still) texture from a 360-camera.
 The mesh is created so that it will be visible when the viewer is inside, rather than outside, of the sphere, with Unity's default backface-culling mode.
 Texture coordinates are based on latitude & longitude (ie an equirectangular map projection) which matches the images from the 360-cameras that we use.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video360Sphere : MonoBehaviour
{
    public int latRes=20, lonRes=40;

    void Start()
        {
        Vector3[] myVerts = new Vector3[latRes*lonRes];
        Vector2[] myUV = new Vector2[latRes*lonRes];
        int index=0;
        for (int j=0; j < latRes; j++)
            {
            for (int i=0; i < lonRes; i++)
                {
                float lat = (j*Mathf.PI)/(latRes-1) - Mathf.PI/2;
                float lon = (i*Mathf.PI*2)/(lonRes-1) - Mathf.PI;
                myVerts[index] = new Vector3(Mathf.Cos(lat)*Mathf.Sin(lon), Mathf.Sin(lat), -Mathf.Cos(lat)*Mathf.Cos(lon));
                myUV[index] = new Vector2(i/(lonRes-1.0f), j/(latRes-1.0f));
                index++;
                }
            }
        int[] myTris = new int[(latRes-1)*(lonRes-1)*2*3];
        index=0;
        for (int j=0; j < latRes-1; j++)
            {
            for (int i=0; i < lonRes-1; i++)
                {
                int corner = i + j*lonRes;
                myTris[index++] = corner;
                myTris[index++] = corner+1;
                myTris[index++] = corner+lonRes;
                myTris[index++] = corner+lonRes;
                myTris[index++] = corner+1;
                myTris[index++] = corner+lonRes+1;
                }
            }
        Mesh myMesh = GetComponent<MeshFilter>().mesh;
        myMesh.Clear();
        myMesh.vertices = myVerts;
        myMesh.uv = myUV;
        myMesh.triangles = myTris;
        myMesh.normals = myVerts;
        }

}