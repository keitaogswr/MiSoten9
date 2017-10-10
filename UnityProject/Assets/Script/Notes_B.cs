using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes_B : MonoBehaviour
{
    public GameObject notes;
    private float taiming;
    private int lineNum = 0;

    private bool bPlay = false;

    public float bpm;
    private float Note_Span = 0;

    public GameObject FieldNote;

    // Use this for initialization
    void Start()
    {
        SpawnNotes();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (FieldNote != null && FieldNote.transform.localPosition.x < 30 && FieldNote.transform.localPosition.x > -30)
            {
                Debug.Log("Good");
            }

        }

    }

    void SpawnNotes()
    {
        GameObject Obj = Instantiate(notes);

        Obj.transform.SetParent(this.transform);

        Obj.transform.localPosition = new Vector2(-510 + (Obj.GetComponent<RectTransform>().rect.width / 2), -330);
        Obj.transform.localScale = new Vector3(1, 1, 1);

        FieldNote = Obj;
    }
}
