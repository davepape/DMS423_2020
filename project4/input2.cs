using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input2 : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 90f;

    void Start()
    {
    }

    void Update()
    {
    transform.Translate(Vector3.up * speed * Time.deltaTime * Input.GetAxis("Vertical"));
    transform.Translate(Vector3.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
//    transform.Rotate(0f, 0f, -turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
