using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarAct : MonoBehaviour {

    private Vector2 Def_Pos;
    private Vector3 Def_Scl;
    private Quaternion Def_Rot;
    private float Timer = 0;

    public Vector3 TargetScl = new Vector3(2,2,2);
    public float SpeedWeight = 2;

    private bool b_Act_Good = false;
    private bool b_Act_Bad = false;

	// Use this for initialization
	void Start () {
        Def_Pos = this.transform.localPosition;
        Def_Scl = this.transform.localScale;
        Def_Rot = this.transform.localRotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (b_Act_Good == true)
        {
            this.transform.localScale = new Vector3(Mathf.Lerp(Def_Scl.x, TargetScl.x, Timer), Mathf.Lerp(Def_Scl.y, TargetScl.y, Timer), 1);
        }
        else
        {
            this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, Def_Scl.x, Timer), Mathf.Lerp(this.transform.localScale.y, Def_Scl.y, Timer), 1);
        }

        if (b_Act_Bad == true)
        {
            this.transform.localPosition = new Vector3(Def_Pos.x, Mathf.Lerp(Def_Pos.y, Def_Pos.y - 30, Timer), 0);
            this.transform.localScale = new Vector3(Mathf.Lerp(Def_Scl.x, Def_Scl.x - 0.5f, Timer), Mathf.Lerp(Def_Scl.y, Def_Scl.y - 0.5f, Timer), 1);
        }
        else if(b_Act_Good == true)
        {

        }
        else 
        {
            this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, Def_Scl.x, Timer), Mathf.Lerp(this.transform.localScale.y, Def_Scl.y, Timer), 1);
            this.transform.localPosition = new Vector3(Def_Pos.x, Mathf.Lerp(this.transform.localPosition.y, Def_Pos.y, Timer), 0);
        }

        Timer += Time.deltaTime;
        Timer *= SpeedWeight;

        if (Timer > 1)
        {
            Timer = 0;
            b_Act_Good = false;
            b_Act_Bad = false;
        }
	}

    public void GoodAct()
    {
        b_Act_Good = true;
    }

    public void BadAct()
    {
        b_Act_Bad = true;
    }
}
