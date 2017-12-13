using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAria : MonoBehaviour {

    [SerializeField]
    private GameObject Parent;

    private ParticleSystem.ShapeModule ShapeMod;

	// Use this for initialization
	void Start () {
        Parent = GameObject.Find(transform.root.gameObject.name + "/Sphere");
        ShapeMod = this.GetComponent<ParticleSystem>().shape;
	}
	
	// Update is called once per frame
	void Update () {
        ShapeMod.radius = Parent.transform.localScale.x;
	}
}
