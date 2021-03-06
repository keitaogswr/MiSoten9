﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DominateBar : MonoBehaviour {

    public float Bar = 0;
    RectTransform BarObj;

    HaveScore Score;

	// Use this for initialization
	void Start ()
    {
        Bar = 0;
        BarObj = this.GetComponent<RectTransform>();
        Score = GameObject.Find("HaveScore").GetComponent<HaveScore>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Bar += 0.01f;

        if(Bar > 1)
        {
            Bar = 1;
        }

        BarObj.transform.localPosition = new Vector3(-570 + (570 * Bar), BarObj.transform.localPosition.y, BarObj.transform.localPosition.z);
        Score.SetDominatePer(Bar);
    }
}
