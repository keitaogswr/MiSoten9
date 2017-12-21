using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveScore : MonoBehaviour {

    [SerializeField]
    private int[] Good = new int[2];

    [SerializeField]
    private int[] Bad = new int[2];

    [SerializeField]
    private int[] Score = new int[2];

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetScore(int score,int P)
    {
        Score[P] = score;
    }

    public void SetGood(int good,int P)
    {
        Good[P] = good;
    }

    public void SetBad(int bad,int P)
    {
        Bad[P] = bad;
    }

    public int GetScore(int id)
    {
        return Score[id];
    }
}
