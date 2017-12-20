using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLogoAnim : MonoBehaviour {

    private bool bFadeout = false;
    private float AnimTime = 0;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        AnimTime += Time.deltaTime;
		if(bFadeout == false)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Lerp(this.transform.localPosition.y, 0, AnimTime * 2), this.transform.localPosition.z);
            
            if(AnimTime > 1.0f)
            {
                bFadeout = true;
            }
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, AnimTime * 60));
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

            if(transform.localScale.x < 0)
            {
                Destroy(this.gameObject);
            }
        }
	}
}
