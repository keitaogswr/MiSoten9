using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {
    public string nextScene;
    private FadeManager fade = null;

	// Use this for initialization
	void Start () {
        fade = GameObject.Find("FadeManager").GetComponent<FadeManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return)) {
            if (fade.getFadeMode() == FadeManager.Fade_Mode.Fade_None) {
                fade.setFade(nextScene);
            }
        }
    }
}
