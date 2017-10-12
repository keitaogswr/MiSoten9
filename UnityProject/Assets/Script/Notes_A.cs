using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes_A : MonoBehaviour {
    public GameObject notes;
    private float taiming;
    private int lineNum = 0;

    private bool bPlay = false;

    public float bpm;
    private float Note_Span = 0;

    public GameObject[] FieldNote = new GameObject[10];

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > Note_Span)
        {
            SpawnNotes();

            Note_Span += 60.0f / bpm / 4;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (FieldNote[0] != null && FieldNote[0].transform.position.x > 50)
            {
                Debug.Log("Good");

                DestoryNote();
            }
            
        }

        if (FieldNote[0] != null && FieldNote[0].transform.position.x > 150)
        {
            DestoryNote();
        }

    }

    void SpawnNotes()
    {
        GameObject Obj = Instantiate(notes);

        Obj.transform.SetParent(this.transform);

        Obj.name = "Note" + lineNum;
        Obj.transform.localPosition = new Vector2(-510 + (Obj.GetComponent<RectTransform>().rect.width/2), -230);
        Obj.transform.localScale = new Vector3(1, 1, 1);

        for (int i = 0; i < 10; i++)
        {
            if (FieldNote[i] == null)
            {
                FieldNote[i] = Obj;
                break;
            }
        }
        lineNum++;
    }

    void DestoryNote()
    {
        FieldNote[0].GetComponent<Note>().DestroyObj();

        for (int i = 0; i < 9; i++)
        {
            FieldNote[i] = FieldNote[i + 1];
        }

        FieldNote[9] = null;
    }
}
