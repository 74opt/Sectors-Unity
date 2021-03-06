using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour { // this is just to store a function to be used
    //public Transform scale;
    //public float health;
    //public float healthMax;

    public static void healthScale(float healthCurrent, float healthMax, Transform healthBar) {
        healthBar.localScale = new Vector3(healthCurrent / healthMax, 1, 1);
    }
}
