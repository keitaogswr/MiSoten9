using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public float sec = 5.0f;
    public float addScal = 0.0f;
    private int AddFunNum = 8000;
    private float elapsedTime = 0.0f;
    private bool drawStart = false;
    private bool drawEnd = false;
    public GameObject drawSphere = null;

    private bool bNextVillage;

    private NextPlace NextPlaceScript;

    private GameObject MiniMapIcon;

    // Use this for initialization
    void Start () {

        NextPlaceScript = GameObject.Find("BoyNextDoorManager").GetComponent<NextPlace>();

        if (drawSphere == null) {
            Debug.Log("オブジェクトが設定されていないので、検索します。");
            drawSphere = GameObject.Find("DrawSphere");
            if (drawSphere == null) {
                Debug.Log("オブジェクトが見つかりませんでした。");
            }
            else {
                Debug.Log("オブジェクトが見つかりました。");
                drawSphere.SetActive(false);
            }
        }
        else {
            drawSphere.SetActive(false);
        }

        MiniMapIcon = GameObject.Find(this.name + "/MinimapIcon_CheckPoint");

        MiniMapIcon.SetActive(false);
        bNextVillage = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (drawStart) {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > sec) {
                drawStart = false;
                elapsedTime = 0.0f;
                drawSphere.SetActive(false);
                drawEnd = true;
            }
            else {
                drawSphere.transform.localScale += new Vector3(addScal, 0, addScal);
            }
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            drawStart = drawEnd == false ? true : false;
            if (!drawEnd) {
                drawSphere.SetActive(true);
            }

            if(bNextVillage)
            {
                Destroy(transform.Find("NextInfoParticle(Clone)").gameObject);
                NextPlaceScript.CheckedPoint();
                bNextVillage = false;
                MiniMapIcon.SetActive(false);
                other.gameObject.GetComponent<Player>().AddFan(AddFunNum);
            }
        }
    }

    public void SetNextVillage()
    {
        MiniMapIcon.SetActive(true);
        bNextVillage = true;
    }
}
