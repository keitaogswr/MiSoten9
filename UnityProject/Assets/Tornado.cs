using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour {

    private float sec = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        sec += Time.deltaTime;

        if (sec > 3.0f) {
            ParticleSystem particlre = GameObject.Find("particle master").GetComponent<ParticleSystem>();
            particlre.loop = false;
        }
	}
}
