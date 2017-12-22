using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour {
    public float time = 5.0f;
    public float speed = 10.0f;
    private float sec = 0.0f;
    private ParticleSystem[] particlre;

    // Use this for initialization
    void Start () {
		AudioManager.Instance.PlaySE("Wind-Synthetic02-2");
		AudioManager.Instance.SetVolumSE(0.1f);

		particlre = this.GetComponentsInChildren<ParticleSystem>();
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
    }
	
	// Update is called once per frame
	void Update () {
        sec += Time.deltaTime;
        transform.position += transform.forward * speed * Time.deltaTime;

        if (sec > time) {
            particlre[1].loop = false;
            if (particlre[1].particleCount <= 0) {
                GameObject.Find("TornadoManager").GetComponent<TornadoManager>().CountDown();
                Destroy(this.gameObject);

            }
        }
	}
}
