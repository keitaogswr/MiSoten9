using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PixelColor : MonoBehaviour
{

    public Camera dispCamera;
    private Texture2D targetTexture;

    // Use this for initialization
    void Start()
    {
        // テクスチャ取得
        Texture2D mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture;   // 本番は地面を向いているカメラからtargetTextureでテクスチャを作る
        int red = 0;
        int blue = 0;

        
        var tex = dispCamera.targetTexture;
        targetTexture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);

        // 取得したテクスチャのすべてのピクセルの色情報を取得
        Color[] colors = mainTexture.GetPixels();
        for (int i = 0; i < colors.Length; i++)
        {

            if (colors[i].r > 0.75f && colors[i].g < 0.25f && colors[i].b < 0.25f)
            {
                red++;
            }
            else if (colors[i].r < 0.25f && colors[i].g < 0.25f && colors[i].b > 0.75f)
            {
                blue++;
            }
        }
    }
}

