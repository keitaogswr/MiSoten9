using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEater : MonoBehaviour {

    public Vector3 MoveSpeed;
    public float DelTime = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.GetComponent<Text>().color = new Color(this.GetComponent<Text>().color.r, this.GetComponent<Text>().color.g, this.GetComponent<Text>().color.b, DelTime);

        this.transform.localPosition += MoveSpeed;

        if (DelTime < 0)
        {
            Destroy(this.gameObject);
        }

        DelTime -= 0.1f;
	}
}
