using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UIを使用可能にする
using UnityEngine.SceneManagement;  // 

public class Fade : MonoBehaviour {

    private GameObject fade;
    private GameObject child;
    public Sprite texture;
    public string cameraName;
    public float fadeSpeed = 0.01f;

    public enum Fade_Mode {
        Fade_None = 0,
        Fade_In,
        Fade_Out,
    };

    private GameObject camera;

    public Fade_Mode fadeMode;
    public Fade_Mode FadeMode { get { return fadeMode; } set { fadeMode = value; } }
    Color color;

    // Use this for initialization
    void Awake () {
        
        DontDestroyOnLoad(this.gameObject);
	}

    void Start () {
        fadeMode = Fade_Mode.Fade_None;
        child = transform.Find("FadePanel").gameObject;
        color = child.GetComponent<Image>().color;
        color.a = 0;
        camera = GameObject.Find(cameraName);

        Vector3 min = camera.GetComponent<Camera>().ScreenToWorldPoint(Vector3.zero);
        min.Scale(new Vector3(1.0f, -1.0f, 1.0f));
        Vector3 max = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        max.Scale(new Vector3(1.0f, -1.0f, 1.0f));

        float width = Screen.width;
        float height = Screen.height;

        child.GetComponent<Image>().GetComponent<RectTransform>().sizeDelta = new Vector2(max.x - min.x, max.y - min.y);
    }

	// Update is called once per frame
	void Update () {
        if (fadeMode != Fade_Mode.Fade_None) {
            child.GetComponent<Image>().color = new Color(color.r, color.g, color.b, color.a);
            color.a += fadeMode == Fade_Mode.Fade_Out ? fadeSpeed : -fadeSpeed;

            if (color.a > 1.0f) {
                color.a = 1.0f;
                fadeMode = Fade_Mode.Fade_In;
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

    public bool setFade () {
        if (fadeMode == Fade_Mode.Fade_None) {
            color.a = 0;
            fadeMode = Fade_Mode.Fade_Out;
            return true;
        }
        return false;
    }

    public Fade_Mode getFadeMode () {
        return fadeMode;
    }

    public GameObject getChild () {
        return child;
    }
}
