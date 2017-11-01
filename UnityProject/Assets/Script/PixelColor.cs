using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelColor : MonoBehaviour
{
	private const float NEARCOLOR = 0.25f;

	public Camera overallCamera;


	[SerializeField]
	TeamColor teamColor = null;

	// Use this for initialization
	void Start()
	{

	}
	// Update is called once per frame
	void Update()
	{
		// クリック時（ゲームの流れが完成したらゲーム終了時に）
		if (Input.GetMouseButtonDown(0))
		{
			CalcPixelColor();

		}

	}

	// 色の比率を計算する関数
	void CalcPixelColor()
	{
		Texture2D tex = new Texture2D(256, 256, TextureFormat.RGB24, false);

		// ofc you probably don't have a class that is called CameraController :P
		Camera activeCamera = overallCamera;

		// Initialize and render
		RenderTexture rt = new RenderTexture(256, 256, 24);
		activeCamera.targetTexture = rt;
		activeCamera.Render();
		RenderTexture.active = rt;

		// Read pixels
		tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);

		// 取得したテクスチャのすべてのピクセルの色情報を取得
		Color[] colors = tex.GetPixels();

		// 得点（仮）
		int team1Score = 0;
		int team2Score = 0;
		//int otherColor = 0;
		for (int i = 0; i < colors.Length; i++)
		{
			if ((colors[i].r > (teamColor.TeamColor1.r - NEARCOLOR) && colors[i].r < (teamColor.TeamColor1.r + NEARCOLOR)) &&
				(colors[i].g > (teamColor.TeamColor1.g - NEARCOLOR) && colors[i].g < (teamColor.TeamColor1.g + NEARCOLOR)) &&
				(colors[i].b > (teamColor.TeamColor1.b - NEARCOLOR) && colors[i].b < (teamColor.TeamColor1.b + NEARCOLOR)))
			{
				team1Score++;
			}
			/*else */
			if ((colors[i].r > (teamColor.TeamColor2.r - NEARCOLOR) && colors[i].r < (teamColor.TeamColor2.r + NEARCOLOR)) &&
			(colors[i].g > (teamColor.TeamColor2.g - NEARCOLOR) && colors[i].g < (teamColor.TeamColor2.g + NEARCOLOR)) &&
			(colors[i].b > (teamColor.TeamColor2.b - NEARCOLOR) && colors[i].b < (teamColor.TeamColor2.b + NEARCOLOR)))
			{
				team2Score++;
			}
			//else
			//{
			//    otherColor++;
			//}
		}

		int ratio1Score = 0;
		int ratio2Score = 0;
		//float ratio1Score = 0;
		//float ratio2Score = 0;

		// チーム１＋チーム２＝１００（塗られていない場所は関与しない）
		ratio1Score = (team1Score * 100) / (team1Score + team2Score);
		ratio2Score = 100 - ratio1Score;

		// チーム１＋チーム２＋OTHER＝１００（塗られていない場所含めて比率１００で計算）
		//float ratio = 100.0f / (team1Score + team2Score + otherColor);
		//ratio1Score = ratio * team1Score;
		//ratio2Score = ratio * team2Score;
		//float noPaint = 100 - (ratio1Score + ratio2Score);

		// Clean up
		activeCamera.targetTexture = null;
		RenderTexture.active = null; // added to avoid errors
		DestroyImmediate(rt);

		Debug.Log("1team:" + ratio1Score);
		Debug.Log("2team:" + ratio2Score);
	}
}

