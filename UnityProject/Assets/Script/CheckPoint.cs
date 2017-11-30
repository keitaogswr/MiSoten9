using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public float sec = 5.0f;
    public float addScal = 0.0f;
    private float elapsedTime = 0.0f;
    private Es.InkPainter.Sample.Paint brush;
    private bool drawStart = false;
    private bool drawEnd = false;
    public GameObject drawSphere = null;
    // Use this for initialization
    void Start () {
        brush = this.GetComponent<Es.InkPainter.Sample.Paint>();
        brush.getBrush().Scale = 0.0f;

        if (drawSphere == null) {
            Debug.Log("オブジェクトが設定されていないので、検索します。");
            drawSphere = GameObject.Find("DrawSphere");
            if (drawSphere == null) {
                Debug.Log("オブジェクトが見つかりませんでした。");
            }
            else {
                Debug.Log("オブジェクトが見つかりました。");
                drawSphere.SetActive(false);
            }
        }
        else {
            drawSphere.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (drawStart) {
            //if (brush.getBrush().Scale > drawRange) {
            //    drawStart = false;
            //    return;
            //}
            //brush.getBrush().Scale += addScal * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            if (elapsedTime > sec) {
                drawStart = false;
                elapsedTime = 0.0f;
                drawSphere.SetActive(false);
                drawEnd = true;
            }
            else {
                drawSphere.transform.localScale += new Vector3(addScal, addScal, addScal);
            }
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            drawStart = drawEnd == false ? true : false;
            if (!drawEnd) {
                drawSphere.SetActive(true);
            }
        }
    }
}
