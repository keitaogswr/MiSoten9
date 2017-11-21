using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public float sec = 5.0f;
    public float drawRange = 5.0f;
    private float addScal = 0.0f;
    private float elapsedTime = 0.0f;
    private Es.InkPainter.Sample.Paint brush;
    private bool drawStart = false;
    private SphereCollider childColl;
    // Use this for initialization
    void Start () {
        childColl = transform.Find("DrawField").GetComponent<SphereCollider>();
        if (childColl != null)
            childColl.enabled = false;
        addScal = drawRange / sec;
        brush = this.GetComponent<Es.InkPainter.Sample.Paint>();
        brush.getBrush().Scale = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (childColl.enabled == true) {
            if (elapsedTime < sec) {
                elapsedTime += Time.deltaTime;
                childColl.radius = addScal * elapsedTime;
            }
        }

        if (drawStart) {
            if (brush.getBrush().Scale > drawRange) {
                drawStart = false;
                return;
            }
            brush.getBrush().Scale += addScal * Time.deltaTime;
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            childColl.enabled = true;
            drawStart = true;
        }
    }
}
