using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveScore : MonoBehaviour {

    public int Good;
    public int Bad;
    public int Score;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetScore(int score)
    {
        Score = score;
    }

    public void SetGood(int good)
    {
        Good = good;
    }

    public void SetBad(int bad)
    {
        Bad = bad;
    }
}
