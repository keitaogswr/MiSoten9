using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSetting : MonoBehaviour {
    public string FindCameraName;
	// Use this for initialization
	void Start () {
        this.GetComponent<Canvas>().worldCamera = GameObject.Find(FindCameraName).GetComponent<Camera>();
	}
}
