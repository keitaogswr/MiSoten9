using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note1 : MonoBehaviour {

    public float Note_Speed = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.right * Note_Speed * Time.deltaTime;

        if (this.transform.localPosition.x > 500 || this.transform.localPosition.x < -500)
        {
            Note_Speed *= -1;
        }
    }
}
