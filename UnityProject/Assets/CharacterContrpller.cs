using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContrpller : MonoBehaviour {

    public enum AnimationName {
        waitLoop_01 = 0,
        waitLoop_02,
        waitLoop_03,
        waitLoop_04,
        waitLoop_05,
        waitLoop_06,
        waveHands,
        turn,
        jump,
        SAK01_Final
    };

    public AnimationName startAnim = AnimationName.waitLoop_01;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
        if (animator  == null) {
            Debug.Log("nullだお");
        }
        startAnimation(startAnim.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startAnimation (string animName) {
        if (animator != null) {
            animator.SetBool(animName, true);
            animator.Play(animName);
        }
    }

    public void changeAnimation (string nowAnim, string nextAnim) {
        if (animator != null) {
            animator.SetBool(nowAnim, false);
            animator.SetBool(nextAnim, true);
        }
    }
}
