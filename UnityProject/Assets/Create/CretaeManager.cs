using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CretaeManager : MonoBehaviour {
    public List<GameObject> prefab;
    private List<GameObject> obj = new List<GameObject>(); 

    void Awake() {
        for (int i = 0; i < prefab.Count; i++) {
            //  オブジェクトがなければ生成。
            if (GameObject.Find(prefab[i].name) == null) {
                obj.Add(Instantiate(prefab[i]) as GameObject);
                obj[i].name = prefab[i].name;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    GameObject getObject(string name) {
        for (int i = 0; i < obj.Count; i++) {
            if (name == obj[i].name) {
                return obj[i];
            }
        }

        return null;
    }
}
