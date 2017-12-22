using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {
    public string nextScene;
    private FadeManager fade = null;
    [SerializeField]
    private GameObject create = null;
	private bool seFlag = false;
	// Use this for initialization
    void Awake () {
        if (!GameObject.Find(create.name)) {
            Debug.Log("createManager is null.");
            GameObject manager = Instantiate(create);
            manager.name = create.name;
        }
    }

	void Start () {
        fade = GameObject.Find("FadeManager").GetComponent<FadeManager>();
        if (fade == null) {
            Debug.Log("fadeManager is null.");
        }
		AudioManager.Instance.PlayBGM("dededon", true);
		AudioManager.Instance.SetVolumeBGM(0.3f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) {
			if (!seFlag)
			{
				seFlag = true;
				AudioManager.Instance.PlaySE("button32");
			}

			if (fade.getFadeMode() == FadeManager.Fade_Mode.Fade_None) {
                fade.setFade(nextScene);
				AudioManager.Instance.StopBGM();

			}
		}
    }
}
