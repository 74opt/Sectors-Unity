using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TempoScript : MonoBehaviour {
    public static float tempo = 160;
    float frequency;
    public static bool tempoActive4;
    public static bool tempoActive2;
    public static bool tempoActive1;

    // Start is called before the first frame update
    void Start() {
        frequency = (float) Math.Pow(tempo / 60, -1);
        Debug.Log(frequency);

        InvokeRepeating("TrueQuarter", 0.35f, frequency);
        InvokeRepeating("TrueHalf", 0.35f, frequency * 2);
        InvokeRepeating("TrueWhole", 0.35f, frequency * 4);

        InvokeRepeating("FalseQuarter", 0.6f, frequency);
        InvokeRepeating("FalseHalf", 0.6f, frequency * 2);
        InvokeRepeating("FalseWhole", 0.6f, frequency * 4);
    }

    void TrueQuarter() {
        tempoActive4 = true;
        //Debug.Log("Quarter True");
    }

    void TrueHalf() {
        tempoActive2 = true;
        //Debug.Log("Half True");
    }

    void TrueWhole() {
        tempoActive1 = true;
        //Debug.Log("Whole True");
    }

    void FalseQuarter() {
        tempoActive4 = false;
        //Debug.Log("Quarter False");
    }

    void FalseHalf() {
        tempoActive2 = false;
        //Debug.Log("Half False");
    }

    void FalseWhole() {
        tempoActive1 = false;
        //Debug.Log("Whole False");
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log(Convert.ToString(tempoActive1) + Convert.ToString(tempoActive2) + Convert.ToString(tempoActive4));
    }
}
