using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titeleScript02 : MonoBehaviour
{

    GameObject TitleLogo, SubTitleLogo, PushBtn;

    float TitleScl, SubTitleScl, alpha;
    bool b_pushBtn;

    // Use this for initialization
    void Start()
    {
        TitleScl = 0;
        SubTitleScl = 0;
        alpha = 0.05f;
        b_pushBtn = false;

        TitleLogo = GameObject.Find("Title_Canvas02/UI_title_0");
        SubTitleLogo = GameObject.Find("Title_Canvas02/UI_title_1");
        PushBtn = GameObject.Find("Title_Canvas02/UI_title_2");
    }

    // Update is called once per frame
    void Update()
    {
        if (TitleScl < 50)
        {
            TitleScl += 2f;
        }
        if (TitleScl >= 50)
        {
            if (SubTitleScl < 50)
            {
                SubTitleScl += 2f;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            b_pushBtn = true;
        }
        if (b_pushBtn)
        {
            alpha = 0.2f;
        }

        TitleLogo.transform.localScale = new Vector3(TitleScl, TitleScl, TitleScl);
        SubTitleLogo.transform.localScale = new Vector3(SubTitleScl, SubTitleScl, SubTitleScl);
        PushBtn.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f + Mathf.Sin(Time.frameCount * alpha));
    }
}
