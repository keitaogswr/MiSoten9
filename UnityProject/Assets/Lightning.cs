using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {
    [SerializeField]
    private float validTime = 0.0f;
    private float workTime = 0.0f;
    bool active = false;
    // Use this for initialization
    void Start () {
		
	}
	private void Awake()
	{
		AudioManager.Instance.PlaySE("nc30620");
	}
	// Update is called once per frame
	void Update () {
        if (active) {
            workTime += Time.deltaTime;
            if (workTime >= validTime) {
                Destroy(this.gameObject);
            }
        }
    }

    public void setVaildTime (float time) {
        validTime = time;
        active = true;
    }
}
