using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject Player;
    public GameObject Player_2P;
    public GameObject Terrain;
    public GameObject Game_UI;
    public GameObject Game_UI_2P;
    public GameObject Flower;

    public GameObject NextInfo;

    public GameObject StartLogo;
    public GameObject StartLogo_2P;

    private GameObject TimerTxt;
    private GameObject TimerTxt_2P;

    public GameObject Bokashi;
    public GameObject Bokashi_2P;

    public GameObject TuText1;
    public GameObject TuText2;

    public GameObject TuText1_2P;
    public GameObject TuText2_2P;

    public GameObject TornadeMane;
    public GameObject LightningMane;

    public GameObject PinkIdol;
    public GameObject BlueIdol;

    public float WaitTimer;
    private float StartTimer;

    public int ClickTime;
    private float ClickCnt;

    public float ChangeSkyValue = 0.5f;
    private float Timer = 0;

    // Use this for initialization
    void Start ()
    {
        Player.GetComponent<Player>().enabled = false;
        Player_2P.GetComponent<Player>().enabled = false;
        Terrain.GetComponent<TerraScript>().enabled = false;
        Terrain.GetComponent<TerrainCollider>().enabled = false;
        Game_UI.GetComponent<Notes_C>().enabled = false;
        Game_UI_2P.GetComponent<Notes_C>().enabled = false;

        NextInfo.GetComponent<NextPlace>().enabled = false;

        TornadeMane.GetComponent<TornadoManager>().enabled = false;
        LightningMane.GetComponent<LightningManager>().enabled = false;

        StartLogo.GetComponent<StartLogoAnim>().enabled = false;
        StartLogo_2P.GetComponent<StartLogoAnim>().enabled = false;

        //GameObject.Find("Player_UI_1/Text").GetComponent<Text>().text = "Wait";
        //GameObject.Find("Player_UI_2/Text").GetComponent<Text>().text = "Wait";

        TimerTxt = GameObject.Find("Player_UI_2/TimerFrame/Timer");
        TimerTxt_2P = GameObject.Find("Player_UI_1/TimerFrame/Timer");

        TimerTxt.GetComponent<Timer>().enabled = false;
        TimerTxt_2P.GetComponent<Timer>().enabled = false;

        StartTimer = 0;
        ClickCnt = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Timer += Time.deltaTime;

        //GameObject.Find("Player_UI_1/Text").GetComponent<Text>().text = "Wait" + Timer;
        //GameObject.Find("Player_UI_2/Text").GetComponent<Text>().text = "Wait" + Timer;

        if (Input.GetKeyDown(KeyCode.Space)||Input.GetButtonDown("Jump"))
        {
            ClickCnt++;
        }

        //if (Timer > WaitTimer)]
        if(ClickTime <= ClickCnt)
        {
            StartTimer += Time.deltaTime;
            
            PinkIdol.GetComponent<CharacterContrpller>().changeAnimationBool(PinkIdol.GetComponent<CharacterContrpller>().startAnim, CharacterContrpller.AnimationName.NOT01_Final);
            BlueIdol.GetComponent<CharacterContrpller>().changeAnimationBool(BlueIdol.GetComponent<CharacterContrpller>().startAnim, CharacterContrpller.AnimationName.NOT01_Final);

            if (StartTimer > 1)
            {
                Player.GetComponent<Player>().enabled = true;
                Player_2P.GetComponent<Player>().enabled = true;
                Terrain.GetComponent<TerrainCollider>().enabled = true;
                Terrain.GetComponent<TerraScript>().enabled = true;
                Game_UI.GetComponent<Notes_C>().enabled = true;
                Game_UI_2P.GetComponent<Notes_C>().enabled = true;

                NextInfo.GetComponent<NextPlace>().enabled = true;

                TimerTxt.GetComponent<Timer>().enabled = true;
                TimerTxt_2P.GetComponent<Timer>().enabled = true;

                TornadeMane.GetComponent<TornadoManager>().enabled = true;
                LightningMane.GetComponent<LightningManager>().enabled = true;

                Destroy(Bokashi);
                Destroy(Bokashi_2P);
                Destroy(this.gameObject);
            }


            StartLogo.GetComponent<StartLogoAnim>().enabled = true;
            StartLogo_2P.GetComponent<StartLogoAnim>().enabled = true;

            Bokashi.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f - StartTimer);
            Bokashi_2P.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f - StartTimer);

            TuText1.GetComponent<Image>().color = new Color(1, 1, 1, 1.0f - StartTimer);
            TuText2.GetComponent<Image>().color = new Color(1, 1, 1, 1.0f - StartTimer);
            TuText1_2P.GetComponent<Image>().color = new Color(1, 1, 1, 1.0f - StartTimer);
            TuText2_2P.GetComponent<Image>().color = new Color(1, 1, 1, 1.0f - StartTimer);

            //Destroy(GameObject.Find("Player_UI_1/Text").gameObject,1);
            //Destroy(GameObject.Find("Player_UI_2/Text").gameObject,1);

            GameObject Obj = Instantiate(Flower);
            Obj.transform.SetParent(Game_UI.transform);
            Obj.transform.localPosition = new Vector3(0, -250, 0);
            DestroyObject(Obj.gameObject, 3);

            GameObject Obj_2 = Instantiate(Flower);
            Obj_2.transform.SetParent(Game_UI_2P.transform);
            Obj_2.transform.localPosition = new Vector3(0, 0, 0);
            Obj_2.layer = LayerMask.NameToLayer("UI2");
            DestroyObject(Obj_2.gameObject, 3);
        }

        
	}
}
