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
    float saveDashHorizontal;
    float saveDashVertical;
    const float playerSpeed = 3.0f;
    float dashTimer;
    const float dashTimeConst = 0.2f;
    const float dashSpeed = 13.0f;
    float dashRechargeTimer;
    const float dashRechargeTimeConst = 2.7f;
    bool playerDashing;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        playerDashing = false;
        dashTimer = dashTimeConst;
        dashRechargeTimer = dashRechargeTimeConst;
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // Makes player face mouse
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90);

        // sets up the dash and activates it 
        if (Input.GetKeyDown(KeyCode.LeftShift) && /*TempoScript.tempoActive2 &&*/ dashTimer > 0 && !playerDashing) {
            saveDashHorizontal = horizontal;
            saveDashVertical = vertical;
            if (horizontal == 0 && vertical == 0) {
                saveDashHorizontal = 1;
            }

            Debug.Log("Dashing");
            playerDashing = true;
            playerAnimator.SetBool("isDash", true);
            //playerAnimator.SetBool("isDash", false);
        }
        
        // recharge timer for when the dash is used
        if (dashTimer <= 0) {
            playerDashing = false;
            playerAnimator.SetBool("isDash", false);
            if (dashRechargeTimer > 0) {
                dashRechargeTimer -= Time.deltaTime;
            } else {
                dashRechargeTimer = dashRechargeTimeConst;
                dashTimer = dashTimeConst;
                Debug.Log("Recharged");
            }
        }

        // timer for the interval that the player is dashing
        if (playerDashing) {
            if (dashTimer > 0) {
                dashTimer -= Time.deltaTime;
            //} else {
            //    playerDashing = false;
            }
        }
        //Debug.Log(horizontal + " " + vertical);
    }   

    // FixedUpdate can run once, zero, or several times per frame, depending on how many physics frames per second are set in the time settings, and how fast/slow the framerate is.
    void FixedUpdate() {
        if (playerDashing && dashTimer >= 0.0f) {
            body.velocity = new Vector2(saveDashHorizontal * dashSpeed, saveDashVertical * dashSpeed);  // dash move
        } else {
            body.velocity = new Vector2(horizontal * playerSpeed, vertical * playerSpeed);  // basic movement
        }
    }
}
