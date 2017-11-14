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

	private Color[] resultColor;
	private float timeCnt = 0.0f;
	// Use this for initialization
	void Start()
	{
		// ピクセル色すべて取得
		Color[] colors = teamColor.tex1.GetPixels();
		// ピクセル色からかぶりのない色を抽出
		System.Collections.Generic.HashSet<Color> hs1 = new System.Collections.Generic.HashSet<Color>(colors);
		resultColor = new Color[hs1.Count];
		// 塗りテクスチャに使う色を被りなく配列に格納
		hs1.CopyTo(resultColor,0);
	}
	// Update is called once per frame
	void Update()
	{
		// クリック時（ゲームの流れが完成したらゲーム終了時に）
		//if (Input.GetMouseButtonDown(0))
		timeCnt += Time.deltaTime;
		if (timeCnt > 0.5f)
		{
			timeCnt = 0.0f;
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
		int otherColor = 0;
		for (int i = 0; i < colors.Length; i++)
		{
			for (int j = 0; j < resultColor.Length; j++)
			{
				float nearR = Mathf.Abs(colors[i].r - resultColor[j].r);
				float nearG = Mathf.Abs(colors[i].g - resultColor[j].g);
				float nearB = Mathf.Abs(colors[i].b - resultColor[j].b);
				if (nearR <= 0.1f/* && nearG <= 0.1f && nearB <= 0.1f*/)
				{
					// 塗られている
					team1Score++;
					break;
				}
				else
				{
					// 塗られていない
					team2Score++;
					if (resultColor.Length == team2Score)
					{
						team2Score = 0;
						otherColor++;
					}
				}
			}

		}

		//int ratio1Score = 0;
		//int ratio2Score = 0;
		float ratio1Score = 0;
		float ratio2Score = 0;

		// チーム１＋チーム２＝１００（塗られていない場所は関与しない）
		if (team1Score == 0 && otherColor == 0)
		{
			Debug.Log("塗られてない");
			return;
		}
		ratio1Score = (float)(team1Score * 100) / (team1Score + otherColor);
		ratio2Score = (float)(100 - ratio1Score);

		// チーム１＋チーム２＋OTHER＝１００（塗られていない場所含めて比率１００で計算）
		//float ratio = 100.0f / (team1Score + team2Score + otherColor);
		//ratio1Score = ratio * team1Score;
		//ratio2Score = ratio * team2Score;
		//float noPaint = 100 - (ratio1Score + ratio2Score);

		// Clean up
		activeCamera.targetTexture = null;
		RenderTexture.active = null; // added to avoid errors
		DestroyImmediate(rt);

		Debug.Log("塗られてる:" + ratio1Score);
		Debug.Log("塗られてない:" + ratio2Score);
	}
}

