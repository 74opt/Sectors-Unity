using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {
    // Variables needed for the class
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float playerSpeed = 7.0f;
    float dashForce;
    public static bool activeDash = true;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() { // Retrieves inputs
        horizontal = Input.GetAxis("Horizontal");  // TODO: Change movement system to use AddForce rather than changing velocity
        vertical = Input.GetAxis("Vertical");
      
        if (Input.GetKey(KeyCode.LeftShift) & activeDash & TempoScript.tempoActive4) {
            dashForce = 5000.0f;
            activeDash = false;
        }
    }

    // FixedUpdate can run once, zero, or several times per frame, depending on how many physics frames per second are set in the time settings, and how fast/slow the framerate is.
    void FixedUpdate() {
        body.velocity = new Vector2(horizontal * playerSpeed, vertical * playerSpeed); // Moves player

        if (dashForce != 0) {
            body.AddForce(transform.right * dashForce);
            dashForce = 0;
        }
    }

}
