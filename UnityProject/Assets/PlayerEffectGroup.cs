using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectGroup : MonoBehaviour {

    public List<GameObject> ring = new List<GameObject>();
    private List<Animator> ringAnimator = new List<Animator>();
    private bool couter = false;
    private bool allAnim = true;

	// Use this for initialization
	void Start () {
		if (ring.Count != 0) {
            couter = true;
            for (int i = 0; i < ring.Count; i++) {
                Animator anim = ring[i].GetComponent<Animator>();
                if (anim != null) {
                    ringAnimator.Add(anim);
                }
                else {
                    allAnim = false;
                }
            }
        }
	}

    public void PlayBang() {
        if (couter && allAnim) {
            for (int i = 0; i < ring.Count; i++) {
                ringAnimator[i].SetTrigger("Bang");
            }
        }
    }
}
