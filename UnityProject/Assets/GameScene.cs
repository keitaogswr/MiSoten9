using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour {
    public string nextScene;
    private FadeManager fade = null;
    [SerializeField]
    private GameObject create = null;

    public GameObject Timer;

    // Use this for initialization
    void Awake() {
        if (GameObject.Find(create.name) == null) {
            Debug.Log("createManager is null.");
            GameObject manager = Instantiate(create);
            manager.name = create.name;
        }
    }

    void Start() {
        fade = GameObject.Find("FadeManager").GetComponent<FadeManager>();
        if (fade == null) {
            Debug.Log("fadeManager is null.");
        }
    }

    // Update is called once per frame
    void Update() {
        //if (Input.GetKey(KeyCode.Return)) {
        if (Timer.GetComponent<Timer>().GetTimeOverFlag() == true) { 
            if (fade.getFadeMode() == FadeManager.Fade_Mode.Fade_None) {
                fade.setFade(nextScene);
                Player player1 = GameObject.Find("Player").GetComponent<Player>();
                Player player2 = GameObject.Find("Player2").GetComponent<Player>();
                player1.transform.DetachChildren();
                player2.transform.DetachChildren();
				AudioManager.Instance.StopBGM();

			}
        }
    }
}
