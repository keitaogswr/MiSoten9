using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes_C : MonoBehaviour
{

    public GameObject notes;
    public GameObject GoodText;
    public GameObject BadText;

    public GameObject GoodEffect;

    private float taiming;
    private int lineNum = 0;

    private bool bPlay = false;

    public float bpm;
    private float Note_Span = 0;

    public GameObject[,] FieldNote = new GameObject[250, 2];

    public GameObject Bar;

    public GameObject TerrainObj;
    public TerraScript TerrainScript;
    public float AddAriaSize;
    public GameObject PlayerObj;
    private Player playerScript;

    [SerializeField]
    private SphereCollider GrowPoint;

    // Use this for initialization
    void Start()
    {
        Bar = GameObject.Find("Hantei_Center").gameObject;
        TerrainObj = GameObject.Find("Terrain").gameObject;
        GrowPoint = GameObject.Find("Player/Sphere").gameObject.GetComponent<SphereCollider>();
        TerrainScript = TerrainObj.GetComponent<TerraScript>();
        PlayerObj = GameObject.Find("Player").gameObject;
        playerScript = PlayerObj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > Note_Span)
        {
            if (lineNum % 1 == 0)
            {
                SpawnNotes();

                Note_Span += 60.0f / bpm / 4;
            }
            else
            {
                SpawnNotes();

                Note_Span += 60.0f / bpm / 4;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (FieldNote[0, 0] != null && FieldNote[0, 0].transform.localPosition.x > -50 && FieldNote[0, 0].transform.localPosition.x < 50)
            {
                //Debug.Log("Good");

                GameObject Good = Instantiate(GoodText);

                Good.transform.SetParent(this.transform);

                Good.name = "Good";
                Good.transform.localPosition = new Vector2(100, -230);
                Good.transform.localScale = new Vector3(2, 2, 2);

                GameObject GEfe = Instantiate(GoodEffect);
                GEfe.transform.SetParent(this.transform);

                GEfe.transform.localPosition = new Vector2(0, -230);
                //GEfe.transform.localScale = new Vector3(2, 2, 2);

                DestroyObject(GEfe, 3);

                //TerrainScript.AriaSize += 5;
                playerScript.addRangeScale(0.001f);

                GrowPoint.isTrigger = false;

                // if (TerrainScript.AriaSize > AddAriaSize)
                // {
                //     TerrainScript.AriaSize = AddAriaSize;
                // }

                Bar.GetComponent<BarAct>().GoodAct();

                DestoryNote();
            }
            else if (FieldNote[0, 0] != null)
            {
                //Debug.Log("Bad");

                GameObject Bad = Instantiate(BadText);

                Bad.transform.SetParent(this.transform);

                Bad.name = "Bad";
                Bad.transform.localPosition = new Vector2(110, -230);
                Bad.transform.localScale = new Vector3(2, 2, 2);

                Bar.GetComponent<BarAct>().BadAct();
                playerScript.subRangeScale(0.001f);
                DestoryNote();

                //GrowPoint.isTrigger = true;
            }
            else
            {
                //GrowPoint.isTrigger = true;
            }

        }

        if (FieldNote[0, 0] != null && FieldNote[0, 0].transform.localPosition.x > 0)
        {
            DestoryNote();
        }

    }

    void SpawnNotes()
    {
        GameObject Obj_L = Instantiate(notes);

        Obj_L.transform.SetParent(this.transform);

        Obj_L.name = "Note" + lineNum;
        Obj_L.transform.localPosition = new Vector2(-510 + (Obj_L.GetComponent<RectTransform>().rect.width / 2), -230);
        Obj_L.transform.localScale = new Vector3(1, 1, 1);

        GameObject Obj_R = Instantiate(notes);

        Obj_R.transform.SetParent(this.transform);

        Obj_R.name = "Note" + lineNum;
        Obj_R.transform.localPosition = new Vector2(510 - (Obj_R.GetComponent<RectTransform>().rect.width / 2), -230);
        Obj_R.transform.localScale = new Vector3(1, 1, 1);

        Obj_R.GetComponent<Note2>().Note_Speed *= -1;

        for (int i = 0; i < 250; i++)
        {
            if (FieldNote[i, 0] == null)
            {
                FieldNote[i, 0] = Obj_L;
                FieldNote[i, 1] = Obj_R;
                break;
            }
        }
        lineNum++;
    }

    void DestoryNote()
    {
        FieldNote[0, 0].GetComponent<Note2>().DestroyObj();
        FieldNote[0, 1].GetComponent<Note2>().DestroyObj();

        for (int i = 0; i < 249; i++)
        {
            FieldNote[i, 0] = FieldNote[i + 1, 0];
            FieldNote[i, 1] = FieldNote[i + 1, 1];
        }

        FieldNote[249, 0] = null;
        FieldNote[249, 1] = null;
    }
}