using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    Weapon testWeapon = new Weapon("test", 23);

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        //testWeapon.TestMethod2(" aaa");
    }
}

public class Weapon {
    public string name;
    public float damage;

    public Weapon(string weaponName, float weaponDamage) {
        name = weaponName;
        damage = weaponDamage;
    }

    public int TestMethod(int x, int y) {
        int num = x * y;
        return num;
    }

    public void TestMethod2(string test) {
        Debug.Log(name + test);
    }
}