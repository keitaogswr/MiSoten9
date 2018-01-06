using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTutorial : MonoBehaviour {

    private float animTime = 0;
    [SerializeField] private float magPosX = 0;           // X軸移動の倍率 
    [SerializeField] private float magPosY = 0.1f;           // Y軸移動の倍率
    [SerializeField] private float magScaleX = 0;         // X軸拡縮の倍率 
    [SerializeField] private float magScaleY = 0;         // Y軸拡縮の倍率

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        // アニメーション時間の加算
        animTime += Time.deltaTime;

        // 画像を上下左右に反復移動する
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y + Mathf.Sin(Time.frameCount * magPosY),
            transform.localPosition.z);

        // 画像を上下左右に反復拡縮する
        transform.localScale = new Vector3(
            Mathf.Sin(animTime * magScaleX) + 1.0f,
            Mathf.Sin(animTime * magScaleY) + 1.0f,
            transform.localScale.z);
    }
}
