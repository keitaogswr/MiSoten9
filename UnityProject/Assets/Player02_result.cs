using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player02_result : MonoBehaviour {

    GameObject ScoreTextObj, FanTextObj, GoodTextObj, BadTextObj, NumTextObj;
    public float CangeColorTime = 0.3f;
    int[] PlayerScore;

    float scorePosX,fanPosX,GoodPosX,BadPosX,NumPosX;
    float time;

    // Use this for initialization
    void Start()
    {
        PlayerScore = new int[6];

        // テキストの初期ポジション
        scorePosX = 700f;
        fanPosX = 10f;
        GoodPosX = 10f;
        BadPosX = 10f;
        NumPosX = 700f;

        //-------------------------------------------------------------------//
        // スコアの設定 ここにスコアの数値いれてね
        //-------------------------------------------------------------------//
        PlayerScore[0] = 60000;     // スコア
        PlayerScore[1] = 500;       // ファン数
        PlayerScore[2] = 400;       // グッド数
        PlayerScore[3] = 80;        // バッド数
        PlayerScore[4] = 75;        // パーセント
        //-------------------------------------------------------------------//
        
        ScoreTextObj    = GameObject.Find("Canvas_Player02/resultScores/ScoreText");
        FanTextObj      = GameObject.Find("Canvas_Player02/resultScores/Fan/FanText");
        GoodTextObj     = GameObject.Find("Canvas_Player02/resultScores/Good/GoodText");
        BadTextObj      = GameObject.Find("Canvas_Player02/resultScores/Bad/BadText");
        NumTextObj      = GameObject.Find("Canvas_Player02/FlowerImage/NumText");

        StartCoroutine("ChangeFontColor");
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTextObj.GetComponent<Text>().text  = "" + PlayerScore[0];
        FanTextObj.GetComponent<Text>().text    = "" + PlayerScore[1];
        GoodTextObj.GetComponent<Text>().text   = "" + PlayerScore[2];
        BadTextObj.GetComponent<Text>().text    = "" + PlayerScore[3];
        NumTextObj.GetComponent<Text>().text    = "" + PlayerScore[4];

        TextMove();
    }

    // テキストの移動処理
    void TextMove()
    {
        time += Time.deltaTime;

        if (time > 3)
        {
            fanPosX -= 1;
            if (fanPosX < 0)
            {
                fanPosX = 0;
            }
        }
        if (time > 3.5f)
        {
            GoodPosX -= 1;
            if (GoodPosX < 0)
            {
                GoodPosX = 0;
            }

        }
        if (time > 4)
        {
            BadPosX -= 1;
            if (BadPosX < 0)
            {
                BadPosX = 0;
            }
        }
        if (time > 4.5f)
        {
            NumPosX -= 50;
            if (NumPosX < 0)
            {
                NumPosX = 0;
            }
        }
        if (time > 5)
        {
            scorePosX -= 50;
            if (scorePosX < 0)
            {
                scorePosX = 0;
            }
        }

        ScoreTextObj.transform.localPosition = new Vector3(70 + scorePosX, 80, 0);
        FanTextObj.transform.localPosition = new Vector3(3 + fanPosX, 0.01f, 0);
        GoodTextObj.transform.localPosition = new Vector3(2.75f + GoodPosX, 0.01f, 0);
        BadTextObj.transform.localPosition = new Vector3(2.98f + BadPosX, 0.01f, 0);
        NumTextObj.transform.localPosition = new Vector3(0 + NumPosX, -8, 0);
    }

    IEnumerator ChangeFontColor()
    {
        while (true)
        {
            yield return StartCoroutine(ChangeColor(Color.red, CangeColorTime));
            yield return StartCoroutine(ChangeColor(Color.green, CangeColorTime));
            yield return StartCoroutine(ChangeColor(Color.blue, CangeColorTime));
        }

        yield break;
    }


    IEnumerator ChangeColor(Color toColor, float duration)
    {
        Color fromColor = ScoreTextObj.GetComponent<Text>().color;

        float startTime = Time.time;
        float endTime = Time.time + duration;
        float marginR = toColor.r - fromColor.r;
        float marginG = toColor.g - fromColor.g;
        float marginB = toColor.b - fromColor.b;

        while (Time.time < endTime)
        {
            fromColor.r = fromColor.r + (Time.deltaTime / duration) * marginR;
            fromColor.g = fromColor.g + (Time.deltaTime / duration) * marginG;
            fromColor.b = fromColor.b + (Time.deltaTime / duration) * marginB;
            ScoreTextObj.GetComponent<Text>().color = fromColor;

            yield return 0;
        }

        ScoreTextObj.GetComponent<Text>().color = toColor;

        yield break;
    }
}


