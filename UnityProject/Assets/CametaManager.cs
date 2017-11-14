using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CametaManager : MonoBehaviour {
    public List<GameObject> obj = new List<GameObject>();
	// Use this for initialization
	void Awake () {
		for (int i = 0; i < obj.Count; i++) {
            GameObject g_Camera = GameObject.Find(obj[i].name);

            if (g_Camera != null) {
                g_Camera.GetComponent<CameraChild>().setCameraTarget();
            }
            else {
                Debug.Log(obj[i].name + " not find");
            }
        }
	}
}
