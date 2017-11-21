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
    // Use this for initialization
    void Start () {
        addScal = drawRange / sec;
        brush = this.GetComponent<Es.InkPainter.Sample.Paint>();
        brush.getBrush().Scale = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
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
            drawStart = true;
        }
    }
}
