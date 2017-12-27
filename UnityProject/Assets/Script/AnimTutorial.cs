using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTutorial : MonoBehaviour {

    private float animTime = 0;
    [SerializeField] private float magPosX = 0;       // X軸移動の倍率 
    [SerializeField] private float magPosY = 1;       // Y軸移動の倍率
    [SerializeField] private float magScaleX = 1;       // X軸移動の倍率 
    [SerializeField] private float magScaleY = 1;       // Y軸移動の倍率

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        // アニメーション時間の加算
        animTime += Time.deltaTime;

        // 画像を上下左右に反復移動する
        Vector3 pos = transform.localPosition;
        pos.x += Mathf.Sin(animTime * magPosX);
        pos.y += Mathf.Sin(animTime * magPosY);
        transform.localPosition = pos;

        // 画像を上下左右に反復拡縮する
        Vector3 scale = transform.localScale;
        scale.x += Mathf.Sin(animTime * magScaleX);
        scale.y += Mathf.Sin(animTime * magScaleY);
        transform.localScale = scale;
    }
}
