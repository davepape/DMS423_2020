// Unity3D script to move all the children of an object in a circle
// Uses "childCount" and "GetChild()" to access all the immediate child nodes
// Positions each on a circle, spreading them evenly around the circle
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleChildren : MonoBehaviour {

    public float speed = 1f;
    public float radius = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            for (int i=0; i < transform.childCount; i++)
                {
                Transform child = transform.GetChild(i);
                float angle = Time.time * speed + 2f*Mathf.PI*i/transform.childCount;
                child.localPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * radius;
                }
	}
}