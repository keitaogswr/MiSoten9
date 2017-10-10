using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    private int qSamples = 1024;

    private float threshold = 0.04f;

    public Transform lowMater, midMater, highMater;

    public float lowFreqThreshold = 14700, midFreqThreshold = 29400, highFreqThreshold = 44100;
    public float lowEnhance = 1.0f, midEnhance = 10.0f, highEnhance = 100.0f;

    private AudioSource audio_;

	// Use this for initialization
	void Start () {
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

        lowMater.localScale = new Vector3(lowMater.localScale.x, low, lowMater.localScale.z);
        midMater.localScale = new Vector3(midMater.localScale.x, mid, midMater.localScale.z);
        highMater.localScale = new Vector3(highMater.localScale.x, low, highMater.localScale.z);
    }
}
