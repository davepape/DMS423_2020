// ship
// by Dave Pape, 5 Oct 2020
//
// Simple Newtonian physics to fly a spaceship.  Gravity is pulling the ship downward.
// If the user pushes the joystick forward, a thrust force will push the ship in the direction it is pointing.
// Moving the joystick left or right will turn the ship.
// If the ship reaches a certain Y value (the ground), a success or failure message is printed.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 gravity = new Vector3(0f, -1f, 0f);
    public float maxThrust = 1f;
    public float turnRate = 90f;

    void Start()
    {
    }

    void Update()
    {
// Turn the ship based on the Horizontal input (joystick X or A/D keys or left/right arrows)
    float orientation = transform.localEulerAngles.z;
    orientation += -Input.GetAxis("Horizontal") * turnRate * Time.deltaTime;
    transform.localEulerAngles = new Vector3(0f, 0f, orientation);

// Apply forces to change the velocity
    Vector3 thrust = Input.GetAxis("Vertical") * maxThrust * transform.up;
    velocity += thrust * Time.deltaTime;
    velocity += gravity * Time.deltaTime;

// Use the velocity to move the ship
    Vector3 position = transform.localPosition;
    position += velocity * Time.deltaTime;
    transform.localPosition = position;

// Simple "collision detection" - if the ship's Y value reaches the ground, do something.
    if (position.y <= 0f)
        {
        if (velocity.magnitude > 5.0f)
            print("BOOM!");
        else
            print("Safe landing!");
        }
    }
}
