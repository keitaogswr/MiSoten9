using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float sec = 0.0f;
    private float time = 0.0f;
    private int Mnt;
    [SerializeField]
    List<Text> text;

	// Use this for initialization
	void Start () {
        Mnt = (int)sec / 60;
        time = 59;
    }
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = 59;

            if(Mnt != 0)
            {
                Mnt--;
            }
        }

        this.GetComponent<Text>().text = Mnt + ":"+(int)time;
    }
}
