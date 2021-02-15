using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    Weapon testWeapon = new Weapon();
    
    // Start is called before the first frame update
    void Start() {
        testWeapon.name = "fish";
        testWeapon.damage = 23;
    }

    // Update is called once per frame
    void Update() {
        testWeapon.testMethod2(" aaa");
    }
}

public class Weapon {
    public string name;
    public float damage;

    public int testMethod(int x, int y) {
        int num = x * y;
        return num;
    }

    public void testMethod2(string test) {
        Debug.Log(name + test);
    }
}