using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    public GameObject fireObject = null;
    private Vector3 hitting_point;
    [SerializeField]
    private float validTime = 0.0f;
    private float workTime = 0.0f;
    bool active = false;
    // Use this for initialization
    void Start () {
		
	}
	private void Awake()
	{
		AudioManager.Instance.PlaySE("THUNDER_Clap_Rumble_01_stereo");
	}
	// Update is called once per frame
	void Update () {
        if (active) {
            workTime += Time.deltaTime;
            if (workTime >= validTime) {
                Destroy(this.gameObject);

                if (fireObject != null) {
                    Instantiate(fireObject, hitting_point, transform.rotation);
                }
            }
        }
    }

    public void setVaildTime (float time) {
        validTime = time;
        active = true;
    }

    void OnCollisionEnter(Collision collision) {
        foreach (ContactPoint point in collision.contacts) {
            hitting_point = point.point;
        }
    }
}
