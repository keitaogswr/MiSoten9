using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapIconMover : MonoBehaviour {

    public GameObject Player;
    public Vector3 Player1stPos;


	// Use this for initialization
	void Start () {
        Player1stPos = Player.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 MoveVec = Player.transform.localPosition - Player1stPos;

        MoveVec /= 10;
        MoveVec *= 4;
       
        this.transform.localPosition = new Vector3((MoveVec.x), -90, 0);
        this.transform.localPosition += new Vector3(0, (MoveVec.z), 0);

    }
}
