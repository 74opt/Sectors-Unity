using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour {
    public Rigidbody2D projectile;
    public const float bulletSpeed = 30.0f;
    Rigidbody2D projectileInstance;

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
            //projectileInstance.AddForce(new Vector2(mouse) * bulletSpeed);
        }
    }
}
