using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoManager : MonoBehaviour {

    public int simultaneous = 3;        //  同時に生成できる数。
    public float createTime = 10.0f;
    public List<GameObject> tornadoPrefab;  //  生成したいトルネードの種類を入れておく。
    [Range(0f, 300.0f)]
    public float createRange = 0.0f;
    private int tornadoNum = 0;
    private float timeCount = 0.0f;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        timeCount += Time.deltaTime;

        if (timeCount >= createTime) {
            timeCount = 0.0f;
            CreateTornado(0);
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            CreateTornado(0);
        }
	}

    public void CreateTornado (params int [] tornado) {
        for (int i = 0; i < tornado.Length; i++) {
            if (tornadoNum < simultaneous - 1) {
                if (tornado[i] < tornadoPrefab.Count) {
                    GameObject obj = Instantiate(tornadoPrefab[tornado[i]], new Vector3(transform.position.x + Random.Range(-createRange, createRange), transform.position.y, transform.position.z + Random.Range(-createRange, createRange)), Quaternion.identity);
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
