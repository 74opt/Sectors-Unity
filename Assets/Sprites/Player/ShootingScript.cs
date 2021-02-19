﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour {
    public Rigidbody2D projectile;
    public Transform spawner;
    public const float bulletSpeed = 15.0f;
    public Transform aim;
    Rigidbody2D projectileInstance;
    public const float bulletTimerConst = 1.0f;
    public float bulletTimer;

    void Start() {
        bulletTimer = bulletTimerConst;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            projectileInstance = Instantiate(projectile, spawner.position, transform.rotation);
            projectileInstance.AddForce(aim.right * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
