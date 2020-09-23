// Unity3d example of using Find() and GetComponent() to control one script from another script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcp : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
		GameObject thecube = GameObject.Find("Cube");
		circle1 circlescript = thecube.GetComponent<circle1>();
		circlescript.speed -= Time.deltaTime;
	}
}
