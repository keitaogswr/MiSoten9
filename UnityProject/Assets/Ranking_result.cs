using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Ranking_result : MonoBehaviour {

    private bool scoreReset = false;

    public int MaxText = 3;
    public int MaxRank = 6;
    public float CangeColorTime = 0.3f;
    bool chkEnd = false;

    GameObject[,] RankObj;
    int[] NewScore, SaveRanking, LoadRanking;
    int[,] Ranking;

    const string SCORE_KEY = "SCORE";

    // Use this for initialization
    void Start()
    {
        RankObj     = new GameObject[MaxRank, MaxText];
        NewScore    = new int[MaxText];
        Ranking     = new int[MaxRank, MaxText];
        SaveRanking = new int[MaxRank * MaxText];
        LoadRanking = new int[MaxRank * MaxText];

        // 読み込み
        LoadRanking = PlayerPrefsX.GetIntArray(SCORE_KEY);

        if(LoadRanking != null)
        {
            int LoadRankCnt = 0;
            for (int i = 0; i < MaxRank; i++)
            {
                for (int j = 0; j < MaxText; j++)
                {
                    Ranking[i, j] = LoadRanking[LoadRankCnt];
                    LoadRankCnt++;
                }
            }
        }
        else
        {
            // ランキングデータ
            Ranking[0, 0] = 50000;
            Ranking[0, 1] = 1;
            Ranking[0, 2] = 500;

            Ranking[1, 0] = 40000;
            Ranking[1, 1] = 2;
            Ranking[1, 2] = 400;

            Ranking[2, 0] = 30000;
            Ranking[2, 1] = 3;
            Ranking[2, 2] = 300;

            Ranking[3, 0] = 20000;
            Ranking[3, 1] = 4;
            Ranking[3, 2] = 200;

            Ranking[4, 0] = 10000;
            Ranking[4, 1] = 5;
            Ranking[4, 2] = 100;
        }

        SetNewScore();

        // スコアのソート処理
        bool isEnd = false;
        while (!isEnd)
        {
            bool loopSwap = false;
            for (int i = 0; i < MaxRank - 1; i++)
            {
                if (Ranking[i, 0] < Ranking[i + 1, 0])
                {
                    Swap(ref Ranking[i, 0], ref Ranking[i + 1, 0]);
                    loopSwap = true;
                }
            }
            if (!loopSwap) // Swapが一度も実行されなかった場合はソート終了
            {
                isEnd = true;
            }
        }

        // ファンのソートと今回のランキングの同期
        if (!chkEnd)
        {
            bool loopChk = false;
            for (int chk = 0; chk < MaxRank; chk++)
            {
                if (NewScore[0] == Ranking[chk, 0])
                {
                    Swap(ref Ranking[5, 2], ref Ranking[chk, 2]);   // ファンのソート
                    NewScore[1] = Ranking[chk, 1];                  // ランキングの同期
                    loopChk = true;
                }
            }
            if (loopChk)
            {
                chkEnd = true;
            }
        }

        // 保存
        int SaveRankCnt = 0;
        for (int i = 0; i < MaxRank; i++)
        {
            for (int j = 0; j < MaxText; j++)
            {
                SaveRanking[SaveRankCnt] = Ranking[i, j];
                SaveRankCnt++;
            }
        }
        PlayerPrefsX.SetIntArray(SCORE_KEY, SaveRanking);

        // ランキングのゲームオブジェクトをファインド
        RankObj[0, 0] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText1/ScoreText1");    // スコア
        RankObj[0, 1] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText1/RankText1");     // ランク
        RankObj[0, 2] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText1/NewFanText1");   // ファン人数

        RankObj[1, 0] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText2/ScoreText2");    // スコア
        RankObj[1, 1] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText2/RankText2");     // ランク
        RankObj[1, 2] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText2/NewFanText2");   // ファン人数

        RankObj[2, 0] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText3/ScoreText3");    // スコア
        RankObj[2, 1] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText3/RankText3");     // ランク
        RankObj[2, 2] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText3/NewFanText3");   // ファン人数

        RankObj[3, 0] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText4/ScoreText4");    // スコア
        RankObj[3, 1] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText4/RankText4");     // ランク
        RankObj[3, 2] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText4/NewFanText4");   // ファン人数

        RankObj[4, 0] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText5/ScoreText5");    // スコア
        RankObj[4, 1] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText5/RankText5");     // ランク
        RankObj[4, 2] = GameObject.Find("Canvas_Player03/Ranking/RankScoreText5/NewFanText5");   // ファン人数

        // 今回のスコアのゲームオブジェクトをファインド
        RankObj[5, 0] = GameObject.Find("Canvas_Player03/NewScoreText/ScoreText");   // スコア
        RankObj[5, 1] = GameObject.Find("Canvas_Player03/NewScoreText/RankText");    // ランク
        RankObj[5, 2] = GameObject.Find("Canvas_Player03/NewScoreText/NewFanText");  // ファン人数

        // テキストカラーチェンジのコルーチン
        StartCoroutine("ChangeFontColor");
    }

    // Update is called once per frame
    void Update()
    {
        // リセット
        if (Input.GetKeyDown(KeyCode.Return))
        {
            scoreReset = true;
        }

        ScoreReset();

        // ランキングの表示
        RankObj[0, 0].GetComponent<Text>().text = "" + Ranking[0, 0];
        RankObj[0, 1].GetComponent<Text>().text = "1";
        RankObj[0, 2].GetComponent<Text>().text = "" + Ranking[0, 2];

        RankObj[1, 0].GetComponent<Text>().text = "" + Ranking[1, 0];
        RankObj[1, 1].GetComponent<Text>().text = "2";
        RankObj[1, 2].GetComponent<Text>().text = "" + Ranking[1, 2];

        RankObj[2, 0].GetComponent<Text>().text = "" + Ranking[2, 0];
        RankObj[2, 1].GetComponent<Text>().text = "3";
        RankObj[2, 2].GetComponent<Text>().text = "" + Ranking[2, 2];

        RankObj[3, 0].GetComponent<Text>().text = "" + Ranking[3, 0];
        RankObj[3, 1].GetComponent<Text>().text = "4";
        RankObj[3, 2].GetComponent<Text>().text = "" + Ranking[3, 2];

        RankObj[4, 0].GetComponent<Text>().text = "" + Ranking[4, 0];
        RankObj[4, 1].GetComponent<Text>().text = "5";
        RankObj[4, 2].GetComponent<Text>().text = "" + Ranking[4, 2];

        // 今回のスコアOBJ
        RankObj[5, 0].GetComponent<Text>().text = "" + NewScore[0];
        RankObj[5, 2].GetComponent<Text>().text = "" + NewScore[2];

        if (NewScore[1] == 0)
        {
            RankObj[5, 1].GetComponent<Text>().text = "圏外";
        }
        else
        {
            RankObj[5, 1].GetComponent<Text>().text = "" + NewScore[1];
        }
    }

    void SetNewScore()
    {
        //---------------------------------------------------//
        // 今回のスコアのデータ（ここにゲームスコアを入れる）
        //---------------------------------------------------//
        Ranking[5, 0] = 60000;  // スコア
        Ranking[5, 1] = 0;      // ランク (ここは数値変えない)
        Ranking[5, 2] = 350;     // ファン数

        // 今回のスコアを保存
        NewScore[0] = Ranking[5, 0];
        NewScore[1] = Ranking[5, 1];
        NewScore[2] = Ranking[5, 2];
    }

    // リセット処理
    void ScoreReset()
    {
        if (scoreReset)
        {
            chkEnd = false;
            // エディタ終了時の処理
            //Ranking = new int[MaxRank, MaxText];
            //SaveRanking = new int[MaxRank * MaxText];

            Ranking[0, 0] = 5000;
            Ranking[0, 1] = 1;
            Ranking[0, 2] = 50;

            Ranking[1, 0] = 4000;
            Ranking[1, 1] = 2;
            Ranking[1, 2] = 40;

            Ranking[2, 0] = 3000;
            Ranking[2, 1] = 3;
            Ranking[2, 2] = 30;

            Ranking[3, 0] = 2000;
            Ranking[3, 1] = 4;
            Ranking[3, 2] = 20;

            Ranking[4, 0] = 1000;
            Ranking[4, 1] = 5;
            Ranking[4, 2] = 10;

            SetNewScore();

            // スコアのソート処理
            bool isEnd = false;
            while (!isEnd)
            {
                bool loopSwap = false;
                for (int i = 0; i < MaxRank - 1; i++)
                {
                    if (Ranking[i, 0] < Ranking[i + 1, 0])
                    {
                        Swap(ref Ranking[i, 0], ref Ranking[i + 1, 0]);
                        loopSwap = true;
                    }
                }
                if (!loopSwap) // Swapが一度も実行されなかった場合はソート終了
                {
                    isEnd = true;
                }
            }

            // ファンのソートと今回のランキングの同期
            if (!chkEnd)
            {
                bool loopChk = false;
                for (int chk = 0; chk < MaxRank; chk++)
                {
                    if (NewScore[0] == Ranking[chk, 0])
                    {
                        Swap(ref Ranking[5, 2], ref Ranking[chk, 2]);   // ファンのソート
                        NewScore[1] = Ranking[chk, 1];                  // ランキングの同期
                        loopChk = true;
                    }
                }
                if (loopChk)
                {
                    chkEnd = true;
                }
            }

            int SaveRankCnt2 = 0;
            for (int i = 0; i < MaxRank; i++)
            {
                for (int j = 0; j < MaxText; j++)
                {
                    SaveRanking[SaveRankCnt2] = Ranking[i, j];
                    SaveRankCnt2++;
                }
            }

            // 保存
            PlayerPrefsX.SetIntArray(SCORE_KEY, SaveRanking);
            scoreReset = false;
        }
    }

    // スワップ
    static void Swap<T>(ref T lhs, ref T rhs)
    {
        T temp;
        temp = lhs;
        lhs = rhs;
        rhs = temp;
    }

    // フォントカラーのコルーチン
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

    // カラーチェンジコルーチン
    IEnumerator ChangeColor(Color toColor, float duration)
    {
        Color fromColor = RankObj[5,0].GetComponent<Text>().color;

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
            RankObj[5,0].GetComponent<Text>().color = fromColor;

            yield return 0;
        }

        RankObj[5,0].GetComponent<Text>().color = toColor;

        for (int chk = 0; chk < MaxRank; chk++)
        {
            if (NewScore[0] == Ranking[chk, 0])
            {
                RankObj[chk, 0].GetComponent<Text>().color = toColor;
            }
        }

        yield break;
    }

    
}
