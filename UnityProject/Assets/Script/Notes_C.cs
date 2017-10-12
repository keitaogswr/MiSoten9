using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes_C : MonoBehaviour {

    public GameObject notes;
    private float taiming;
    private int lineNum = 0;

    private bool bPlay = false;

    public float bpm;
    private float Note_Span = 0;

    public GameObject[,] FieldNote = new GameObject[10,2];

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > Note_Span)
        {
            SpawnNotes();

            Note_Span += 60.0f / bpm / 4;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (FieldNote[0,0] != null && FieldNote[0,0].transform.localPosition.x > -50 && FieldNote[0, 0].transform.localPosition.x < 50)
            {
                Debug.Log("Good");

                DestoryNote();
            }

        }

        if (FieldNote[0,0] != null && FieldNote[0,0].transform.localPosition.x > 0)
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

        for (int i = 0; i < 10; i++)
        {
            if (FieldNote[i,0] == null)
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
        FieldNote[0,0].GetComponent<Note2>().DestroyObj();
        FieldNote[0, 1].GetComponent<Note2>().DestroyObj();

        for (int i = 0; i < 9; i++)
        {
            FieldNote[i,0] = FieldNote[i + 1,0];
            FieldNote[i, 1] = FieldNote[i + 1, 1];
        }

        FieldNote[9,0] = null;
        FieldNote[9, 1] = null;
    }
}
