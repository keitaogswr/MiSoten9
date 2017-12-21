using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour {

    public string nextScene;
    private FadeManager fade = null;
    [SerializeField]
    private GameObject create = null;

    // Use this for initialization
    void Awake() {
        if (!GameObject.Find(create.name)) {
            Debug.Log("createManager is null.");
            GameObject manager = Instantiate(create);
            manager.name = create.name;
        }
    }

    void Start () {
        AudioManager.Instance.PlaySE("se_maoudamashii_instruments_drumroll");

        fade = GameObject.Find("FadeManager").GetComponent<FadeManager>();
        if (fade == null) {
            Debug.Log("fadeManager is null.");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return)) {
            if (fade.getFadeMode() == FadeManager.Fade_Mode.Fade_None) {
                fade.setFade(nextScene);
            }
        }

        Destroy(GameObject.Find("HaveScore"));
    }
}
