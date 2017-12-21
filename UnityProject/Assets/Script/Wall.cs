using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {


	public GameObject HitEff;		// ヒットエフェクト

	void OnCollisionStay(Collision col)
	{
		// ヒットした相手がプレイヤーなら
		if (col.gameObject.tag == "Player")
		{
			// 壁ヒットエフェクト
			GameObject Obj = Instantiate(HitEff);
			Obj.transform.SetParent(this.transform);
			Obj.transform.position = col.transform.position;
			Obj.transform.localRotation = this.transform.localRotation;
			DestroyObject(Obj.gameObject, 0.15f);
		}
	}

}
