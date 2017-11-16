using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class uv : MonoBehaviour {
    [Range(-1.0f, 1.0f)]
    public float move_x = 0.0f;
    [Range(-1.0f, 1.0f)]
    public float move_y = 0.0f;
    private RawImage texture;
	// Use this for initialization
	void Start () {
        texture = GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
        texture.uvRect = new Rect(texture.uvRect.x + move_x, texture.uvRect.y + move_y, texture.uvRect.width, texture.uvRect.height);
	}
}
