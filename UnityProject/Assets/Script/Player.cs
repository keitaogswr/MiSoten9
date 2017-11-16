using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    PlayerSetteing parameter = null;
    [SerializeField]
    GameObject paintField = null;
    public PlayerNum playerNum = PlayerNum.Player_1;
    public enum PlayerNum {
        Player_1 = 1,
        PLayer_2,
    };

    private float moveSpeed = 0.0f;
    private float maxSpeed = 0.0f;
    private float minSpeed = 0.0f;
    private float acceleration = 0.1f;
    private float slope = 0.0f;
    private float acceleSlope = 0.0f;

    private string vertical;
    private string horizontal;

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
        vertical = "Vertical_" + (int)playerNum;
        horizontal = "Horizontal_" + (int)playerNum;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    private void Move () {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis(vertical) == 1) {
            if (moveSpeed < maxSpeed) {
                moveSpeed += acceleration;
            }
            else {
                moveSpeed = maxSpeed;
            }
        }
        else {
            if (minSpeed < moveSpeed) {
                moveSpeed -= acceleration;
            }
            else {
                moveSpeed = minSpeed;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis(horizontal) == 1) {
            slope += acceleSlope;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis(horizontal) == -1) {
            slope -= acceleSlope;
        }

        transform.rotation = Quaternion.Euler(0, transform.rotation.y + slope, 0);
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
    }

    public void setMoveSpeed(float speed) {
        moveSpeed = speed;
    }
}
