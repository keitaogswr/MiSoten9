using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasReset : MonoBehaviour {

    public GameObject child;

    // Use this for initialization
    void Start () {
        if (child == null) {
            child = transform.Find("FadePanel").gameObject;
        }
        else {
            Camera camera = this.GetComponent<Canvas>().worldCamera;

            Vector3 min = camera.GetComponent<Camera>().ScreenToWorldPoint(Vector3.zero);
            min.Scale(new Vector3(1.0f, -1.0f, 1.0f));
            Vector3 max = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
            max.Scale(new Vector3(1.0f, -1.0f, 1.0f));
            child.GetComponent<RawImage>().GetComponent<RectTransform>().sizeDelta = new Vector2(max.x - min.x, max.y - min.y);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
