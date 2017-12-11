using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyboxChenger : MonoBehaviour {

    public List<Material> skybox = new List<Material>();
    private DominateBar bar;
    public float ChangeSkyValue = 0.5f;

    // Use this for initialization
    void Start () {
        bar = GameObject.Find("Player_UI_1/DominateBarBack/DominateBar").GetComponent<DominateBar>();
    }
	
	// Update is called once per frame
	void Update () {
        if (bar.Bar > ChangeSkyValue) {
            setSkyboxTexture(1);
        }
    }

    public void setSkyboxTexture (int num) {
        if (num < skybox.Count && num > -1) {
            RenderSettings.skybox = skybox[num];
        }
    }
}
