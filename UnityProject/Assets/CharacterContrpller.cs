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
        SAK01_Final,
        NOT01_Final
    };

    public AnimationName startAnim = AnimationName.waitLoop_01;

    private AnimationName nowAnimName;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
        if (animator  == null) {
            Debug.Log("nullだお");
        }
        startAnimationBool(startAnim);
        nowAnimName = startAnim;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startAnimationBool(AnimationName animName) {
        if (animator != null) {
            animator.SetBool(animName.ToString(), true);
            animator.Play(animName.ToString());
        }
    }

    public void changeAnimationBool(AnimationName nowAnim, AnimationName nextAnim) {
        if (animator != null) {
            animator.SetBool(nowAnim.ToString(), false);
            animator.SetBool(nextAnim.ToString(), true);
        }
    }

    public void startAnimationTrigger (AnimationName animName) {
        if (animator != null) {
            animator.SetTrigger(animName.ToString());
            animator.Play(animName.ToString());
        }
    }

    public void changeAnimationTrigger(AnimationName nowAnim, AnimationName nextAnim) {
        if (animator != null) {
            animator.SetTrigger(nowAnim.ToString());
            animator.SetTrigger(nextAnim.ToString());
        }
    }

    public AnimationName getNowAnimName () {
        return nowAnimName;
    }
}
