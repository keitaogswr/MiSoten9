using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraCtrl : MonoBehaviour {

    private GameObject player = null;
    Vector3 GoalPosition, Rot = Vector3.zero, Pos;
    private Vector3 offset = Vector3.zero;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //offset = this.transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        offset = this.transform.position - player.transform.position;
        Rot.y = player.transform.rotation.y;
        Vector3 newPosition = this.transform.position;

        GoalPosition.x = player.transform.position.x - (offset.x * Mathf.Sin(Rot.y));
        GoalPosition.z = player.transform.position.z - (offset.z * Mathf.Cos(Rot.y));

        Pos.x += (GoalPosition.x - this.transform.position.x) * 0.06f;
        Pos.z += (GoalPosition.z - this.transform.position.z) * 0.06f;
        Pos.y = player.transform.position.y + offset.y;

        this.transform.position = Pos;

        //newPosition.x = player.transform.position.x + offset.x;
        //newPosition.y = player.transform.position.y + offset.y;
        //newPosition.z = player.transform.position.z + offset.z;


        //this.transform.position = newPosition;
    }
}
