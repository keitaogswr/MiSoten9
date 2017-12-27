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
    private int CheckedPointCnt = 0;

    private float timer = 0;
    private float SpawnDeray = 5;
    

	// Use this for initialization
	void Start ()
    {
        SpawndNum = 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject Icon;

        int Rand,RandOld = 0;

		if(bNext == false)
        {
            timer += Time.deltaTime;

            if(SpawnDeray < timer)
            {
                for (var i = 0; i < 2; i++)
                {
                    Rand = Random.Range(0, 5);
                    while(Rand == RandOld)
                    {
                        Rand = Random.Range(0, 5);
                    }
                    switch (Rand)
                    {
                        case 0:
                            Icon = Instantiate(NextIcon);
                            Icon.transform.position = Village.transform.position + new Vector3(0, 30, 10);
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
                    RandOld = Rand;
                }
                bNext = true;
            }
        }
	}

    public void CheckedPoint()
    {
        CheckedPointCnt++;
        if(CheckedPointCnt == SpawndNum)
        {
            CheckedPointCnt = 0;
            ClearPoint();
        }
    }

    public void ClearPoint()
    {
        bNext = false;
        timer = 0;
    }
}
