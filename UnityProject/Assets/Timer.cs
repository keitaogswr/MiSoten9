using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float sec = 0.0f;
    private float time = 0.0f;
    [SerializeField]
    List<Text> text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (time < sec) {
            time += Time.deltaTime;
        }

        for (int i = 0; i < text.Count; i++) {
            text[i].text = "TIME:" + time;
        }
    }
}
