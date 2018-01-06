using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireEffect : MonoBehaviour {

    public float scale_quantity = 0.1f;

    private SphereCollider coll;

    // Use this for initialization
    void Start () {
        coll = this.GetComponent<SphereCollider>();
    }
	
	// Update is called once per frame
	void Update () {
        coll.radius += scale_quantity;
    }
}
