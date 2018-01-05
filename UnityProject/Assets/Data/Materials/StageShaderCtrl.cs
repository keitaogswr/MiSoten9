using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageShaderCtrl : MonoBehaviour {

    private MaterialPropertyBlock MatPro;

    private Material Mat;

    private Renderer Renderer;

    private int qSamples = 1024;

    private float threshold = 0.04f;

    //public Transform lowMater, midMater, highMater;

    public float lowFreqThreshold = 14700, midFreqThreshold = 29400, highFreqThreshold = 44100;
    public float lowEnhance = 1.0f, midEnhance = 10.0f, highEnhance = 100.0f;

    private AudioSource audio_;

    // Use this for initialization
    void Start () {
        Renderer = this.GetComponent<Renderer>();
        this.Mat = Renderer.material;
        MatPro = new MaterialPropertyBlock();

        audio_ = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        var spectrum = audio_.GetSpectrumData(qSamples, 0, FFTWindow.Hamming);

        var deltaFreq = AudioSettings.outputSampleRate / qSamples;
        float low = 0.0f, mid = 0.0f, high = 0.0f;

        for (var i = 0; i < qSamples; i++)
        {
            var freq = deltaFreq * i;

            if (freq <= lowFreqThreshold) low += spectrum[i];
            else if (freq <= midFreqThreshold) mid += spectrum[i];
            else if (freq <= highFreqThreshold) high += spectrum[i];

        }

        low *= lowEnhance;
        mid *= midEnhance;
        high *= highEnhance;

        MatPro.Clear();
        MatPro.SetVector("_LocalPos", transform.localPosition);
        MatPro.SetFloat("_Tester", low);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MatPro.SetFloat("_Tester", high);
        }

        Renderer.SetPropertyBlock(MatPro);
	}
}
