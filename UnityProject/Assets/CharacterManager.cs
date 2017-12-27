using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    public List<GameObject> character = new List<GameObject>();
    public CharacterContrpller.AnimationName playAnim = CharacterContrpller.AnimationName.turn;
    private List<CharacterContrpller> charaAnim = new List<CharacterContrpller>();

	// Use this for initialization
	void Start () {
		if (character.Count > 0) {
            for (int i = 0; i < character.Count; i++) {
                charaAnim.Add(character[i].GetComponent<CharacterContrpller>());
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
            PlayAnim();
        }
	}

    public void PlayAnim() {
        if (charaAnim.Count > 0) {
            for (int i = 0; i < charaAnim.Count; i++) {
                charaAnim[i].changeAnimationBool(charaAnim[i].getNowAnimName(), playAnim);
            }
        }
    }
}
