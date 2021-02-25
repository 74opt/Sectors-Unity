using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    Rigidbody2D body;
    public Transform playerTransform;
    public Transform enemyHealthBar;
    const float enemySpeed = 1.5f;
    float enemyHealth;
    const float enemyHealthConst = 7.0f;

    void Start() {
        enemyHealth = 7.0f;
        playerTransform = GameObject.Find("Player").transform;
    }

    void Update() {
        if (enemyHealth <= 0) {
            Destroy(gameObject);
        }

        enemyHealthBar.localScale = new Vector3(enemyHealth/enemyHealthConst, 1, 1);

        if (PlayerScript.playerDead) {
            playerTransform = null;
        }
    }

    void FixedUpdate() {
        if (!PlayerScript.playerDead) {
            // looks towards player
            transform.rotation = Quaternion.LookRotation(Vector3.forward, playerTransform.position - transform.position);

            // moves towards player
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, enemySpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Player Projectile") {
            enemyHealth -= ShootingScript.damage;
        }
    }
}
