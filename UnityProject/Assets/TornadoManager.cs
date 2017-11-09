using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoManager : MonoBehaviour {

    public int simultaneous = 3;        //  同時に生成できる数。
    public float createRange = 50.0f;   //  生成範囲。
    public List<GameObject> tornadoPrefab;  //  生成したいトルネードの種類を入れておく。

    private int tornadoNum = 0;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) {
            CreateTornado(0);
        }
	}

    public void CreateTornado (params int [] tornado) {
        for (int i = 0; i < tornado.Length; i++) {
            if (tornadoNum < simultaneous - 1) {
                if (tornado[i] < tornadoPrefab.Count) {
                    GameObject obj = Instantiate(tornadoPrefab[tornado[i]]);
                    obj.name = tornadoPrefab[tornado[i]].name;
                    CountUp();
                }
            }
        }
    }

    public void RandomCreateTornado (int createNum = 1) {
        createNum = createNum > simultaneous ? simultaneous : createNum;

        int num = Random.Range(1, createNum);
        for (int i = 0; i < num; i++) {
            if (tornadoNum < simultaneous - 1) {
                int index = Random.Range(0, tornadoPrefab.Count);
                Instantiate(tornadoPrefab[num]);
                CountUp();
            }
        }
    }

    public void CountUp () {
        tornadoNum++;
    }

    public void CountDown () {
        tornadoNum--;
    }
}
