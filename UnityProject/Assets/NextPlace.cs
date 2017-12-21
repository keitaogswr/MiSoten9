using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPlace : MonoBehaviour {

    public GameObject NextIcon;

    public GameObject Village;
    public GameObject Village_2;
    public GameObject Village_3;
    public GameObject Village_4;
    public GameObject Village_5;

    private bool bNext = false;

    private int SpawndNum;

    private float timer = 0;
    private float SpawnDeray = 5;

	// Use this for initialization
	void Start ()
    {
        SpawndNum = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject Icon;

        int Rand;

		if(bNext == false)
        {
            timer += Time.deltaTime;

            if(SpawnDeray < timer)
            {
                Rand = Random.Range(0, 5);

                switch(Rand)
                {
                    case 0:
                        Icon = Instantiate(NextIcon);
                        Icon.transform.position = Village.transform.position + new Vector3(0,30,10);
                        Icon.transform.SetParent(Village.transform);
                        Village.GetComponent<CheckPoint>().SetNextVillage();
                        break;
                    case 1:
                        Icon = Instantiate(NextIcon);
                        Icon.transform.position = Village_2.transform.position + new Vector3(0, 30, 10);
                        Icon.transform.SetParent(Village_2.transform);
                        Village_2.GetComponent<CheckPoint>().SetNextVillage();
                        break;
                    case 2:
                        Icon = Instantiate(NextIcon);
                        Icon.transform.position = Village_3.transform.position + new Vector3(0, 30, 10);
                        Icon.transform.SetParent(Village_3.transform);
                        Village_3.GetComponent<CheckPoint>().SetNextVillage();
                        break;
                    case 3:
                        Icon = Instantiate(NextIcon);
                        Icon.transform.position = Village_4.transform.position + new Vector3(0, 30, 10);
                        Icon.transform.SetParent(Village_4.transform);
                        Village_4.GetComponent<CheckPoint>().SetNextVillage();
                        break;
                    case 4:
                        Icon = Instantiate(NextIcon);
                        Icon.transform.position = Village_5.transform.position + new Vector3(0, 30, 10);
                        Icon.transform.SetParent(Village_5.transform);
                        Village_5.GetComponent<CheckPoint>().SetNextVillage();
                        break;
                }
                bNext = true;
            }
        }
	}

    public void ClearPoint()
    {
        bNext = false;
        timer = 0;
    }
}
