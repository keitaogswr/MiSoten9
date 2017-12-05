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

    public float WaitTimer;
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
        

        GameObject.Find("Player_UI_1/Text").GetComponent<Text>().text = "Wait";
        GameObject.Find("Player_UI_2/Text").GetComponent<Text>().text = "Wait";
    }
	
	// Update is called once per frame
	void Update ()
    {
        Timer += Time.deltaTime;

        GameObject.Find("Player_UI_1/Text").GetComponent<Text>().text = "Wait" + Timer;
        GameObject.Find("Player_UI_2/Text").GetComponent<Text>().text = "Wait" + Timer;

        if (Timer > WaitTimer)
        {
            Player.GetComponent<Player>().enabled = true;
            Player_2P.GetComponent<Player>().enabled = true;
            Terrain.GetComponent<TerrainCollider>().enabled = true;
            Terrain.GetComponent<TerraScript>().enabled = true;
            Game_UI.GetComponent<Notes_C>().enabled = true;
            Game_UI_2P.GetComponent<Notes_C>().enabled = true;

            Destroy(this.gameObject);

            GameObject.Find("Player_UI_1/Text").GetComponent<Text>().text = "Start";
            GameObject.Find("Player_UI_2/Text").GetComponent<Text>().text = "Start";

            Destroy(GameObject.Find("Player_UI_1/Text").gameObject,1);
            Destroy(GameObject.Find("Player_UI_2/Text").gameObject,1);
        }
	}
}
