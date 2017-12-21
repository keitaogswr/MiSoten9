using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FanDraw : MonoBehaviour {

    public GameObject haveScore;
    public int PlayerID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.GetComponent<Text>().text = "" + haveScore.GetComponent<HaveScore>().GetScore(PlayerID);		
	}
}
