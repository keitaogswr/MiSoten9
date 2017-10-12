using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public GameObject[] ChildObj;
    

	// Use this for initialization
	void Start () {
        var childTransform = this.GetComponentsInChildren<Transform>();
        int Count = 0;
        foreach (Transform child in childTransform)
        {

            ChildObj[Count] = child.gameObject;
            Count++;
        }
    }
	
	// Update is called once per frame
	void Update () {

        ChildObj[3].GetComponent<Transform>().localScale += new Vector3(0, 0.01f, 0);
	}
}
