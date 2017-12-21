using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetter : MonoBehaviour {

    public List<Vector3> cameraPos = new List<Vector3>();       //  設定するカメラの座標。
    public List<string> findCameraName = new List<string>();    //  設定するカメラの名前。

	// Use this for initialization
	void Start () {
        //  カメラの座標のリストの数とカメラの名前のリストの数同じにしてね。しないと殺す。

        if (findCameraName.Count > 0) {
            for (int i = 0; i < findCameraName.Count; i++) {
                //  リストに登録されている名前のカメラを探す。
                GameObject cameraObj = GameObject.Find(findCameraName[i]);
                if (cameraObj != null) {    //  存在すれば。
                    if (cameraPos.Count >= i) {     //  座標用のリストカウントを超えてなかったら。
                        //  リストの座標に設定。
                        cameraObj.transform.position = cameraPos[i];
                    }
                }
            }
        }
	}

}
