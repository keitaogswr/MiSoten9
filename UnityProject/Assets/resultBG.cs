using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resultBG : MonoBehaviour {

    float flower01_PosY;
    public GameObject flower01;

	// Use this for initialization
	void Start () {
        flower01 = GameObject.Find("UI_result_2");
        flower01.transform.localPosition = new Vector2(0,20);
        flower01_PosY = 0;
    }
	
	// Update is called once per frame
	void Update () {
        flower01.transform.localPosition = new Vector2(0, 20);
    }
}
