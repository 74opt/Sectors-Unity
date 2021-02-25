using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour {
    public Rigidbody2D projectile;
    public Transform spawner;
    public const float bulletSpeed = 15.0f;
    public Transform aim;
    Rigidbody2D projectileInstance;
    //SpriteRenderer gunInstance;
    public const float bulletTimerConst = 1.0f;
    public float bulletTimer;
    public Animator animator;
    public float randomSpread;
    public static float damage;
    //float animatorTimerConst = .1f;
    //float animatorTimer;

    void Start() {
        bulletTimer = bulletTimerConst;
        damage = 3.0f;
        //animatorTimer = animatorTimerConst;
        //gunInstance = Instantiate(gun);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) /*&& TempoScript.tempoActive4*/) {
            randomSpread = Random.Range(-.1f, .1f);

            projectileInstance = Instantiate(projectile, spawner.position + new Vector3(randomSpread, 0, 0), transform.rotation);
            projectileInstance.AddForce(aim.right * bulletSpeed, ForceMode2D.Impulse);
            animator.SetTrigger("OnShoot");
            //animator.ResetTrigger("OnShoot");
        }
    }
}
