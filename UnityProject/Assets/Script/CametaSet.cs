using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CametaSet : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnDestroy () {
        if (this.transform.parent != null) {
            this.transform.parent = null;
        }
    }
}
