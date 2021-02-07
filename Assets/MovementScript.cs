using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {
    // Variables needed for the class
    Rigidbody2D body;
    public Animator playerAnimator;
    Vector3 mousePos;
    float horizontal;
    float vertical;
    float playerSpeed = 7.0f;
    float dashForce;
    bool activeDash = true;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxis("Horizontal");  // TODO: Change movement system to use AddForce rather than changing velocity
        vertical = Input.GetAxis("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // Makes player face mouse
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90);


        if (Input.GetKey(KeyCode.LeftShift) && activeDash && TempoScript.tempoActive2) {
            playerAnimator.SetBool("isDash", true);
            dashForce = 5000.0f;
            activeDash = false;
        }

        if (!activeDash) {
            
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
