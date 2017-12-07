using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public string nextScene;
    private FadeManager fade = null;
    [SerializeField]
    private GameObject create = null;

    private bool gameStart = false;
    private bool gameFinish = false;

    void Awake () {
        if (!GameObject.Find(create.name)) {
            GameObject manager = Instantiate(create);
            manager.name = create.name;
        }
    }

    // Use this for initialization
    void Start () {
        fade = GameObject.Find("FadeManager").GetComponent<FadeManager>();
        if (fade == null) {
            Debug.Log("fadeManager is null.");
        }

        gameStart = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool getGameStart () {
        return gameStart;
    }

    public bool getGameEnd () {
        return gameFinish;
    }
}
