using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note2 : MonoBehaviour {

    public float Note_Speed = 10;

    private Timer timer;

    // Use this for initialization
    void Start()
    {
        timer = GameObject.Find("Player_UI_1/TimerFrame/Timer").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.GetTimeOverFlag())
        {
        }
        else
        {
            this.transform.position += Vector3.right * Note_Speed * Time.deltaTime;
        }
        
    }

    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}
