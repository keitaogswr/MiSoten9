using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UIを使用可能にする
using UnityEngine.SceneManagement;  

public class FadeManager : MonoBehaviour {
    [SerializeField]
    List<GameObject> fadeList;

    public Sprite texture;
    private List<GameObject> obj = new List<GameObject>();
    private string nextScene;

    public enum Fade_Mode {
        Fade_None = 0,
        Fade_In,
        Fade_Out,
    };

    Fade_Mode FadeMode;

    // Use this for initialization
    void Awake () {
		for (int i = 0; i < fadeList.Count; i++) {
            obj.Add(Instantiate(fadeList[i]) as GameObject);
            fadeList[i].GetComponent<Canvas>().targetDisplay = i;
            Debug.Log( "display_num : " + fadeList[i].GetComponent<Canvas>().targetDisplay);
            obj[i].name = fadeList[i].name;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start () {
        nextScene = null;
        FadeMode = Fade_Mode.Fade_None;
    }	
	// Update is called once per frame
	void Update () {
		if (FadeMode != Fade_Mode.Fade_None) {
            int fadeInCount = 0;
            for (int i = 0; i < fadeList.Count; i++) {
                if ((Fade_Mode)obj[i].GetComponent<Fade>().getFadeMode() == Fade_Mode.Fade_In) {
                    ++fadeInCount;
                }
            }
            if (fadeInCount == fadeList.Count && FadeMode != Fade_Mode.Fade_In) {
                FadeMode = Fade_Mode.Fade_In;
                SceneManager.LoadScene(nextScene);
                fadeInCount = 0;
            }
        }
	}

    public bool setFade (string sceneName) {
        nextScene = sceneName;
        FadeMode = Fade_Mode.Fade_Out;
        
        for (int i = 0; i < fadeList.Count; i++) {
            //if (fadeList[i].GetComponent<Fade>().getFadeMode() == Fade.Fade_Mode.Fade_None) {
            Fade fade = obj[i].GetComponent<Fade>();
            fade.setFade();
            //}
        }
        return true;
    }

    public void setTexture (Sprite sprite) {
        for (int i = 0; i < fadeList.Count; i++) {
            obj[i].GetComponent<Fade>().getChild().GetComponent<Image>().sprite = sprite;
        }
    }

    public void setTexture (Sprite sprite, int index) {
        obj[index].GetComponent<Fade>().getChild().GetComponent<Image>().sprite = sprite;
    }

    public Fade_Mode getFadeMode () {
        return FadeMode;
    }
}
