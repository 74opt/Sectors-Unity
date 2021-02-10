using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TempoScript : MonoBehaviour {
    public static float tempo = 120;
    float frequency;
    public static bool tempoActive4;
    public static bool tempoActive2;
    public static bool tempoActive1;

    // Start is called before the first frame update
    void Start() {
        frequency = (float) Math.Pow(tempo / 60 / .25, -1);
        Debug.Log(frequency);

        InvokeRepeating("TrueQuarter", 0.0f, frequency);
        InvokeRepeating("TrueHalf", 0.0f, frequency * 2);
        InvokeRepeating("TrueWhole", 0.0f, frequency * 4);

        InvokeRepeating("FalseQuarter", 0.03f, frequency);
        InvokeRepeating("FalseHalf", 0.03f, frequency * 2);
        InvokeRepeating("FalseWhole", 0.03f, frequency * 4);
    }

    void TrueQuarter() {
        tempoActive4 = true;
    }

    void TrueHalf() {
        tempoActive2 = true;
    }

    void TrueWhole() {
        tempoActive1 = true;
    }

    void FalseQuarter() {
        tempoActive4 = false;
    }

    void FalseHalf() {
        tempoActive2 = false;
    }

    void FalseWhole() {
        tempoActive1 = false;
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log(Convert.ToString(tempoActive1) + Convert.ToString(tempoActive2) + Convert.ToString(tempoActive4));
    }
}
