using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {
    // Variables needed for the class
    Rigidbody2D body;

    float horizontal;
    float vertical;

    float playerSpeed = 5.0f;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() { // Retrieves inputs
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    // FixedUpdate can run once, zero, or several times per frame, depending on how many physics frames per second are set in the time settings, and how fast/slow the framerate is.
    void FixedUpdate() {
        body.velocity = new Vector2(horizontal * playerSpeed, vertical * playerSpeed); // Moves player
    }

}
