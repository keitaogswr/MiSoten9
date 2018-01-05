using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcLine : MonoBehaviour {

    public GameObject PlayerObj;
    private Player playerScript;
    ParticleSystem Part;

    float PartAlpha;

    // Use this for initialization
    void Start () {
        if (PlayerObj == null)
        {
            PlayerObj = GameObject.Find("Player").gameObject;
        }
        playerScript = PlayerObj.GetComponent<Player>();

        Part = this.GetComponent<ParticleSystem>();
        
    }
	
	// Update is called once per frame
	void Update () {

        if (playerScript.Axel >= 4)
        {
            PartAlpha = 0.75f;
        }
        else if (playerScript.Axel >= 3)
        {
            PartAlpha = 0.5f;
        }
        else if (playerScript.Axel >= 2)
        {
            PartAlpha = 0.25f;
        }
        else if (playerScript.Axel == 1)
        {
            PartAlpha = 0;
        }

        Part.startColor = new Color(1, 1, 1, PartAlpha);
    }
}
