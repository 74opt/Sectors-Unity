using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    Rigidbody2D body;
    public Transform playerTransform;
    const float enemySpeed = 1.7f;

    void Start() {
        
    }

    void Update() {
        
    }

    void FixedUpdate() {
        // looks towards player
        transform.rotation = Quaternion.LookRotation(Vector3.forward, playerTransform.position - transform.position);

        // moves towards player
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, enemySpeed * Time.deltaTime);
    }
}
