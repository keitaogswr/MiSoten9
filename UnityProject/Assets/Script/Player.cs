using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    PlayerSetteing parameter = null;

    private float moveSpeed = 0.0f;
    private float maxSpeed = 0.0f;
    private float minSpeed = 0.0f;
    private float acceleration = 0.1f;
    private float slope = 0.0f;
    private float acceleSlope = 0.0f;

    // Use this for initialization
    void Start () {
        if (parameter != null) {
            maxSpeed = parameter.maxSpeed;
            minSpeed = parameter.minSpeed;
            acceleration = parameter.acceleration;
            acceleSlope = parameter.acceleSlope;
        }
        else {
            Debug.Log("param is null");
        }
	}
	
	// Update is called once per frame
	void Update () {
        move();
    }

    private void move () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (moveSpeed < maxSpeed)
            {
                moveSpeed += acceleration;
            }
            else
            {
                moveSpeed = maxSpeed;
            }
        }
        else
        {
            if (minSpeed < moveSpeed)
            {
                moveSpeed -= acceleration;
            }
            else
            {
                moveSpeed = minSpeed;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            slope += acceleSlope;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            slope -= acceleSlope;
        }

        transform.rotation = Quaternion.Euler(0, transform.rotation.y + slope, 0);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
