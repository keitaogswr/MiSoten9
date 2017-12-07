using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player02_result : MonoBehaviour {

    GameObject ScoreTextObj, FanTextObj, GoodTextObj, BadTextObj, NumTextObj;
    public float CangeColorTime = 0.3f;

    // Use this for initialization
    void Start()
    {
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
        ScoreTextObj.GetComponent<Text>().text  = "114514";
        FanTextObj.GetComponent<Text>().text    = "1919";
        GoodTextObj.GetComponent<Text>().text   = "810";
        BadTextObj.GetComponent<Text>().text    = "30";
        NumTextObj.GetComponent<Text>().text    = "100";
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


