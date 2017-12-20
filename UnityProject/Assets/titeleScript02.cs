using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titeleScript02 : MonoBehaviour
{
    GameObject TitleLogo, SubTitleLogo, PushBtn;

    float TitleAlpha, SubTitleAlpha, BtnAlpha;
    bool b_pushBtn;

    // Use this for initialization
    void Start()
    {
        TitleAlpha = 0;
        SubTitleAlpha = 0;
        BtnAlpha = 0.05f;
        b_pushBtn = false;

        TitleLogo = GameObject.Find("Title_Canvas02/UI_title_0");
        SubTitleLogo = GameObject.Find("Title_Canvas02/UI_title_1");
        PushBtn = GameObject.Find("Title_Canvas02/UI_title_2");

        PushBtn.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (TitleAlpha < 1.0f)
        {
            TitleAlpha += 0.02f;
        }
        if (TitleAlpha >= 1.0f)
        {
            if (SubTitleAlpha < 1.0f)
            {
                SubTitleAlpha += 0.02f;
            }
            if (SubTitleAlpha >= 1.0f)
            {
                PushBtn.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f + Mathf.Sin(Time.frameCount * BtnAlpha));
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            b_pushBtn = true;
        }
        if (b_pushBtn)
        {
            BtnAlpha = 0.2f;
        }

        //TitleLogo.transform.localScale = new Vector3(TitleAlpha, TitleAlpha, TitleAlpha);
        //SubTitleLogo.transform.localScale = new Vector3(SubTitleAlpha, SubTitleAlpha, SubTitleAlpha);

        TitleLogo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0f + TitleAlpha);
        SubTitleLogo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0f + SubTitleAlpha);
        PushBtn.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f + Mathf.Sin(Time.frameCount * BtnAlpha));
    }
}
