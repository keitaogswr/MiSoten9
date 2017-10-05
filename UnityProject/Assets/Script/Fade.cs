using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UIを使用可能にする
using UnityEngine.SceneManagement;  // 

public class Fade : MonoBehaviour {

    private GameObject fade;
    private GameObject child;
    public Sprite texture;
    public float fadeSpeed = 0.01f;

    public enum Fade_Mode {
        Fade_None = 0,
        Fade_In,
        Fade_Out,
    };

    Fade_Mode fadeMode;
    Color color;
    string nextScene;

    // Use this for initialization
    void Awake () {
        child = transform.Find("FadePanel").gameObject;
        DontDestroyOnLoad(this.gameObject);
	}

    void Start () {
        nextScene = null;
        fadeMode = Fade_Mode.Fade_None;

        color = child.GetComponent<Image>().color;
        color.a = 0;
    }

	// Update is called once per frame
	void Update () {
        if (fadeMode != Fade_Mode.Fade_None) {
            child.GetComponent<Image>().color = new Color(color.r, color.g, color.b, color.a);
            color.a += fadeMode == Fade_Mode.Fade_Out ? fadeSpeed : -fadeSpeed;

            if (color.a > 1.0f) {
                fadeMode = Fade_Mode.Fade_In;
                SceneManager.LoadScene(nextScene);
            }
            else if (color.a < 0.0f) {
                color.a = 0.0f;
                fadeMode = Fade_Mode.Fade_None;
            }
        }
	}

    void SetTexture (Sprite texture) {
        child.GetComponent<Image>().sprite = texture;
    }

    public bool setFade (string sceneName) {
        if (fadeMode == Fade_Mode.Fade_None) {
            color.a = 0;
            nextScene = sceneName;
            fadeMode = Fade_Mode.Fade_Out;
            return true;
        }
        return false;
    }
}
