using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    PlayerSetteing parameter = null;
    [SerializeField]
    GameObject paintField = null;
    public PlayerNum playerNum = PlayerNum.Player_1;
    public enum PlayerNum {
        Player_1 = 1,
        PLayer_2,
    };

    [SerializeField]
    private Vector3 Good_Bad_Score = new Vector3(0,0,0); //ｘ：Good数　Y：Bad数　Z：スコア

    private float moveSpeed = 0.0f;
    private float maxSpeed = 0.0f;
    private float minSpeed = 0.0f;
    private float acceleration = 0.1f;
    private float slope = 0.0f;
    private float acceleSlope = 0.0f;
    private Es.InkPainter.Sample.Paint brush;

    private string vertical;
    private string horizontal;

    private GameObject HightTarget;     //色塗りの判定オブジェクト
   
    public GameObject PlayerObj;        //比空戦
    public GameObject PlayerCamera;     //追従カメラ

    public float LerpHight = 40;
    public float LerpAngle = -80;
    private float LerpTimer = 0;

    public float Axel = 1;

    private GameObject HaveScore; 

    // Use this for initialization
    void Start () {
        if (parameter != null) {
            maxSpeed = parameter.maxSpeed;
            minSpeed = parameter.minSpeed;
            acceleration = parameter.acceleration;
            acceleSlope = parameter.acceleSlope;
            //PlayerObj = GameObject.Find("Player/Capsule");

            if (PlayerCamera == null) {
                if (this.name != "Player") {
                    PlayerCamera = GameObject.Find("Player2/Capsule/SubCamera");
                }
                else {
                    PlayerCamera = GameObject.Find("Player/Capsule/Main Camera");
                }
            }

            HightTarget = GameObject.Find("Player/Sphere");
            HightTarget.transform.localScale = new Vector3(parameter.DrawAriaSize, HightTarget.transform.localScale.y, transform.localScale.z);
        }
        else {
            Debug.Log("param is null");
        }
        vertical = "Vertical_" + (int)playerNum;
        horizontal = "Horizontal_" + (int)playerNum;

        brush = this.GetComponent<Es.InkPainter.Sample.Paint>();

        HaveScore = GameObject.Find("HaveScore");
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        HaveScore.GetComponent<HaveScore>().SetScore((int)Good_Bad_Score.z);
        HaveScore.GetComponent<HaveScore>().SetGood((int)Good_Bad_Score.x);
        HaveScore.GetComponent<HaveScore>().SetBad((int)Good_Bad_Score.y);
    }

    private void Move () {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis(vertical) == 1)
		{
            if (moveSpeed < maxSpeed) {
                moveSpeed += acceleration;
            }
            else {
                moveSpeed = maxSpeed;
            }

		}
        else
		{
            if (minSpeed < moveSpeed) {
                moveSpeed -= acceleration;
            }
            else {
                moveSpeed = minSpeed;
            }
        }

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis(horizontal) == 1) {
            slope += acceleSlope;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis(horizontal) == -1) {
            slope -= acceleSlope;
        }

        transform.rotation = Quaternion.Euler(0, transform.rotation.y + slope, 0);
        
        if((int)HightTarget.transform.localPosition.y > -6)
        {
            LerpHight = 100;
        }
        else if((int)HightTarget.transform.localPosition.y < -6 && (int)HightTarget.transform.localPosition.y > -17)
        {
            LerpHight = 70;
            LerpAngle = -0.45f;
        }
        else
        {
            LerpHight = 50;
            LerpAngle = -0.6f;
        }

        if (PlayerObj.transform.position.y != LerpHight)
        {
            LerpTimer = 0;
        }

        transform.position += transform.forward * moveSpeed * Axel * Time.deltaTime;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, 500), transform.position.y, Mathf.Clamp(transform.position.z, 0, 500));

        LerpTimer += Time.deltaTime;

        PlayerObj.transform.position = new Vector3(transform.position.x,Mathf.Lerp(PlayerObj.transform.position.y, LerpHight, LerpTimer),transform.position.z);
        PlayerCamera.transform.localRotation = new Quaternion(Mathf.Lerp(PlayerCamera.transform.localRotation.x, LerpAngle, LerpTimer), PlayerCamera.transform.localRotation.y, PlayerCamera.transform.localRotation.z, PlayerCamera.transform.localRotation.w);
        
        if(LerpAngle == -0.45f)
        {
            PlayerCamera.transform.localPosition = new Vector3(0, -7, Mathf.Lerp(PlayerCamera.transform.localPosition.z, -6, LerpTimer));
        }
        else
        {
            PlayerCamera.transform.localPosition = new Vector3(0, -7, Mathf.Lerp(PlayerCamera.transform.localPosition.z, -1, LerpTimer));
        }

        //transform.position = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.position.y, LerpHight, LerpTimer), transform.localPosition.z);
        if (LerpTimer > 1)
        {
            LerpTimer = 1;
        }
    }

    public void setMoveSpeed(float speed) {
        moveSpeed = speed;
    }

    //public void addRangeScale (float additional) {
    //    brush.getBrush().Scale += additional;
    //}

    //public void subRangeScale(float subtract) {
    //    brush.getBrush().Scale -= subtract;
    //}

    //public void setRangeScale (float scal) {
    //    brush.getBrush().Scale = scal;
    //}

    public void AddGood()
    {
        Good_Bad_Score += new Vector3(1, 0, 0);
    }

    public void AddBad()
    {
        Good_Bad_Score += new Vector3(0, 1, 0);
    }

    public void AddFan(int AddNum)
    {
        Good_Bad_Score += new Vector3(0, 0, AddNum);
    }
}
