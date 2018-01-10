using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireEffect : MonoBehaviour {

    public float scale_quantity = 0.1f;
    public GameObject drawObj = null;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        drawObj.transform.localScale += new Vector3(scale_quantity, 0, 0);
    }
}
