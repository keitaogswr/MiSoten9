using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CretaeManager : MonoBehaviour {
    public List<GameObject> prefab;
    static private List<GameObject> obj; 

    void Awake() {
        for (int i = 0; i < prefab.Count; i++) {
            //  オブジェクトがなければ生成。
            if (GameObject.Find(prefab[i].name) == null) {
                obj.Add(Instantiate(prefab[i]) as GameObject);
                obj[i].name = prefab[i].name;
            }
        }
    }

    GameObject getObject(string name) {
        for (int i = 0; i < prefab.Count; i++) {
            if (name == prefab[i].name) {
                return prefab[i];
            }
        }

        return null;
    }
}
