using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DominateBar : MonoBehaviour {

    public float Bar = 0;
    RectTransform BarObj;

	// Use this for initialization
	void Start ()
    {
        Bar = 0;
        BarObj = this.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Bar += 0.01f;

        if(Bar > 1)
        {
            Bar = 1;
        }

        BarObj.anchorMax = new Vector2(Bar, 0.5f);
	}
}
