using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class veiwTitleScript : MonoBehaviour {

    GameObject TitleLogo, SubTitleLogo;

    float TitleAlpha, SubTitleAlpha;

    // Use this for initialization
    void Start()
    {
        TitleAlpha = 0;
        SubTitleAlpha = 0;

        TitleLogo = GameObject.Find("Title_Canvas03/UI_title_0");
        SubTitleLogo = GameObject.Find("Title_Canvas03/UI_title_1");
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
        }

        //TitleLogo.transform.localScale = new Vector3(TitleAlpha, TitleAlpha, TitleAlpha);
        //SubTitleLogo.transform.localScale = new Vector3(SubTitleAlpha, SubTitleAlpha, SubTitleAlpha);

        TitleLogo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0f + TitleAlpha);
        SubTitleLogo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0f + SubTitleAlpha);
    }
}
