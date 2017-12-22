using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRigManager : MonoBehaviour {

    public List<GameObject> cameraObj = new List<GameObject>();
    public float changeSec = 2.0f;
    private float counter = 0.0f;

	// Use this for initialization
	void Start () {
        if (cameraObj.Count > 0) {
            int index = Random.Range(0, cameraObj.Count);
            for (int i = 0; i < cameraObj.Count; i++) {
                GameObject cameraRig = cameraObj[i];
                if (i == index) {
                    //cameraRig.gameObject.SetActive(true);
                    cameraRig.GetComponentInChildren<Camera>().depth = 0;
                }
                else {
                    //cameraRig.gameObject.SetActive(false);
                    cameraRig.GetComponentInChildren<Camera>().depth = -1;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        if (counter > changeSec) {
            counter = 0;
            int index = Random.Range(0, cameraObj.Count);
            for (int i = 0; i < cameraObj.Count; i++) {
                //Camera cameraRig = cameraObj[i].GetComponentInChildren<Camera>();
                GameObject cameraRig = cameraObj[i];
                if (i == index) {
                    //cameraRig.gameObject.SetActive(true);
                    //cameraRig.GetComponentInChildren<CameraSwitcher>().StartAutoChange();
                    //cameraRig.transform.FindChild("Camera Switcher").GetComponent<CameraSwitcher>().enabled = false;
                    cameraRig.GetComponentInChildren<Camera>().depth = 0;
                }
                else {
                    cameraRig.GetComponentInChildren<Camera>().depth = -1;
                    //cameraRig.transform.FindChild("Camera Switcher").GetComponent<CameraSwitcher>().enabled = true;
                    //cameraRig.gameObject.SetActive(false);
                }
            }
        }
    }
}
