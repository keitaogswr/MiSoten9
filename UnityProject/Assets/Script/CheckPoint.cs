using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public float sec = 5.0f;
    public float drawRange = 5.0f;
    private float addScal = 0.0f;
    private float elapsedTime = 0.0f;

    private SphereCollider childColl;
    // Use this for initialization
    void Start () {
        childColl = transform.FindChild("DrawField").GetComponent<SphereCollider>();
        if (childColl != null)
            childColl.enabled = false;
        addScal = drawRange / sec;
    }
	
	// Update is called once per frame
	void Update () {
        if (childColl.enabled == true) {
            if (elapsedTime < sec) {
                elapsedTime += Time.deltaTime;
                childColl.radius = addScal * elapsedTime;
                
            }
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            childColl.enabled = true;
        }
    }
}
