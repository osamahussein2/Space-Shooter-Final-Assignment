using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;

    public float acceleration;

    public float maxSpeed = 7.0f; 
    public float accelerationTime = 2.5f;

    void Start()
    {
        acceleration = 0.0f;
    }

    void Update()
    {
        OnlyAccelerate();
    }

    private void OnlyAccelerate()
    {
        Vector3 direction = Vector3.zero;

        // Moving up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            acceleration += (maxSpeed / accelerationTime) * Time.deltaTime;
            direction += Vector3.up;
        }

        // Moving down
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            acceleration += (maxSpeed / accelerationTime) * Time.deltaTime;
            direction += Vector3.down;
        }

        // Moving left
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            acceleration += (maxSpeed / accelerationTime) * Time.deltaTime;
            direction += Vector3.left;
        }

        // Moving right
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            acceleration += (maxSpeed / accelerationTime) * Time.deltaTime;
            direction += Vector3.right;
        }

        // If the player isn't holding any movement keys
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow) &&
            !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow) &&
            !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow) &&
            !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow))
        {
            // Set the acceleration to 0 to make the player come to complete stop after letting go of input
            acceleration = 0.0f;
        }

        if (acceleration > 0.0f)
        {
            if (acceleration > maxSpeed)
            {
                acceleration = maxSpeed;
            }

            direction.Normalize();
        }

        // Move the player around
        transform.position += acceleration * Time.deltaTime * direction;
    }

}
