using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningManager : MonoBehaviour {
    public GameObject LightningPrefab;
    [Range(0, 100)]
    public float range_min = 0;
    [Range(0, 200)]
    public float range_max = 50;

    public float creation_interval = 10.0f;     //  雷を生成する間隔。
    public float survival_time = 2.0f;          //  雷自体の生存時間。
    private float createCounter = 0.0f;         //  TDNカウンター。

    public List<GameObject> fall_point = new List<GameObject>();        //  落とす場所のリスト。

    // Use this for initialization
    void Start () {
		if (LightningPrefab == null) {
            Debug.Log("prefabセットしてちょ。");
        }
	}
	
	// Update is called once per frame
	void Update () {
        //  スペース押されたら生成。
		if (Input.GetKeyDown(KeyCode.Space)) {
            RandomCreate();
        }

        //  カウントアップ。
        createCounter += Time.deltaTime;
        //  生成時間に達したら。
        if (creation_interval <= createCounter) {
            //  ランダムに落とすか、拠点に落とすかをランダムで決定。
            int fallCheckPoint = Random.Range(0, 1);

            if (fallCheckPoint == 0) {  //  ランダムな場所に落とす。
                RandomCreate();
            }
            else {
                if (fall_point.Count > 0) {     //  落とす場所があればその中からランダムなところを選んで雷を落とす。
                    int fallNum = Random.Range(0, fall_point.Count);
                    CreateLightning(fall_point[fallNum].transform.position, survival_time);
                }
                else {  //  リストがなければランダムな場所に落とす。
                    Debug.Log("落とす場所無いからテキトーにおとすわ。");
                    RandomCreate();
                }
            }
            createCounter = 0;
        }
    }

    public void CreateLightning (Vector3 posision, float validTime) {
        GameObject obj = Instantiate(LightningPrefab, posision, LightningPrefab.transform.rotation);
        Lightning lightning = obj.GetComponent<Lightning>();
        lightning.setVaildTime(validTime);
    }

    public void RandomCreate () {
        Vector3 createPos = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * Random.Range(range_min, range_max) + this.transform.position;
        createPos = new Vector3(createPos.x, transform.position.y, createPos.z);
        CreateLightning(createPos, 2.0f);
    }
}
