using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChild : MonoBehaviour {
    public GameObject target = null;
    public Vector3 pos;
	// Use this for initialization
	void Start () {
        setCameraTarget();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setCameraTarget () {
        if (target != null) {
            GameObject obj = GameObject.Find(target.name);
            if (obj != null) {
                this.transform.parent = obj.transform;
                this.transform.localPosition = pos;
            }
        }
    }
}
