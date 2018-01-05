using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour {

    [SerializeField]
    private float validTime = 0.0f;
    private float workTime = 0.0f;

    public GameObject createObj = null;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        workTime += Time.deltaTime;
        if (workTime >= validTime) {
            Destroy(this.gameObject);

            if (createObj != null) {
                Instantiate(createObj);
            }
        }
    }
}
