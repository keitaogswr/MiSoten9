using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningManager : MonoBehaviour {
    public GameObject LightningPrefab;
    [Range(0, 100)]
    public float range_min = 0;
    [Range(0, 200)]
    public float range_max = 50;
    // Use this for initialization
    void Start () {
		if (LightningPrefab == null) {
            Debug.Log("prefabセットしてちょ。");
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 createPos = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * Random.Range(range_min, range_max) + this.transform.position;
            createPos = new Vector3(createPos.x, transform.position.y, createPos.z);
            CreateLightning(createPos, 5.0f);
        }
	}

    public void CreateLightning (Vector3 posision, float validTime) {
        GameObject obj = Instantiate(LightningPrefab, posision, LightningPrefab.transform.rotation);
        Lightning lightning = obj.GetComponent<Lightning>();
        lightning.setVaildTime(validTime);
    }
}
