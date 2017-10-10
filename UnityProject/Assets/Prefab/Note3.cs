using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note3 : MonoBehaviour {

    public float Note_Speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.right * Note_Speed * Time.deltaTime;
	}

    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}
