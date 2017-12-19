using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float sec = 0.0f;
    private float time = 0.0f;
    private int Mnt;

    private GameObject TimeOverText;

	// Use this for initialization
	void Start ()
    {
        Mnt = (int)sec / 60;
        time = (int)sec % 60;

        TimeOverText = GameObject.Find(this.transform.root.transform.gameObject.name + "/TIMEOVER_TEXT");
    }
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;
        if (time < 1)
        {
            time = 59;

            if(Mnt != 0)
            {
                Mnt--;

                if(Mnt < 0)
                {
                    Mnt = 0;
                }
            }
            else
            {
                TimeOverText.transform.localPosition = new Vector3(Mathf.Lerp(TimeOverText.transform.localPosition.x,0,0.25f + Time.deltaTime * 5), TimeOverText.transform.localPosition.y, TimeOverText.transform.localPosition.z);

                time = 0;
            }
        }

        if(time < 10)
        {
            this.GetComponent<Text>().text = Mnt + ":0" + (int)time;
        }
        else
        {
            this.GetComponent<Text>().text = Mnt + ":" + (int)time;
        }
        
    }
}
