using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyalumeController : MonoBehaviour {

    public float lowFreqThreshold = 14700, midFreqThreshold = 29400, highFreqThreshold = 44100;
    public float lowEnhance = 1.0f, midEnhance = 10.0f, highEnhance = 100.0f;

    private Renderer renderer = null;
    private AudioSource audio = null;
    private int qSamples = 1024;

    // Use this for initialization
    void Start() {
        renderer = this.GetComponent<Renderer>();
        audio = GameObject.Find("AudioManager").GetComponent<AudioManager>().getBGMAudioSource();
    }

    // Update is called once per frame
    void Update() {
        var spectrum = audio.GetSpectrumData(qSamples, 0, FFTWindow.Hamming);

        var deltaFreq = AudioSettings.outputSampleRate / qSamples;
        float low = 0.0f, mid = 0.0f, high = 0.0f;

        for (var i = 0; i < qSamples; i++) {
            var freq = deltaFreq * i;

            if (freq <= lowFreqThreshold) low += spectrum[i];
            else if (freq <= midFreqThreshold) mid += spectrum[i];
            else if (freq <= highFreqThreshold) high += spectrum[i];

        }

        low *= lowEnhance;
        mid *= midEnhance;
        high *= highEnhance;

        this.baseColor = new Color(low, high, mid);
        this.waveX = low;
    }

    public Color baseColor {
        get { return renderer.material.GetColor("_BaseColor"); }
        set { renderer.material.SetColor("_BaseColor", value); }
    }

    public float waveX {
        get { return renderer.material.GetFloat("_WaveFactorX"); }
        set { renderer.material.SetFloat("_WaveFactorX", value); }
    }
}
