using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
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
    float playerHealth;
    const float playerHealthConst = 20.0f;
    const float gracePeriodTimerConst = .7f;
    float gracePeriodTimer;
    bool gracePeriodBool;
    public Transform healthBar;
    public static bool playerDead;
    GameObject barScale;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        playerDashing = false;
        playerHealth = playerHealthConst;
        dashTimer = dashTimeConst;
        dashRechargeTimer = dashRechargeTimeConst;
        gracePeriodTimer = gracePeriodTimerConst;
        Transform playerHealthBar = Instantiate(healthBar, transform.position + new Vector3(.1f, .33f, 0), transform.rotation);
        playerHealthBar.transform.parent = gameObject.transform;
        gracePeriodBool = false;
        playerHealthBar.transform.localScale = new Vector3(75, 10, 1);
        playerDead = false;
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // sets up mouse position for player rotations
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  

        // sets up the dash and activates it 
        if (Input.GetKeyDown(KeyCode.LeftShift) && /*TempoScript.tempoActive2 &&*/ dashTimer > 0 && !playerDashing) {
            saveDashHorizontal = horizontal;
            saveDashVertical = vertical;
            //if (horizontal > 0) {
            //    saveDashHorizontal = 1;
            //} else if (horizontal < 0) {
            //    saveDashHorizontal = -1;
            //}

            //if (vertical > 0) {
            //    saveDashVertical = 1;
            //} else if (vertical < 0) {
            //    saveDashVertical = -1;
            //}

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
            }
        }

        HealthBarScript.healthScale(playerHealth, playerHealthConst, GameObject.Find("HealthBar(Clone)/Bar").transform);

        if (gracePeriodBool) {
            if (gracePeriodTimer > 0) {
                gracePeriodTimer -= Time.deltaTime;
            } else {
                gracePeriodTimer = gracePeriodTimerConst;
                gracePeriodBool = false;
            }
        }

        //BoolTimer(gracePeriodTimer, gracePeriodTimerConst, gracePeriodBool);
    }   

    //void BoolTimer(float timer, float timerConst, bool boolean) {
    //    if (boolean) {
    //        if (timer > 0) {
    //            timer -= Time.deltaTime;
    //        } else {
    //            timer = timerConst;
    //            boolean = false;
    //        }
    //    }
    //}

    // FixedUpdate can run once, zero, or several times per frame, depending on how many physics frames per second are set in the time settings, and how fast/slow the framerate is.
    void FixedUpdate() {
        if (playerDashing && dashTimer >= 0.0f) {
            body.velocity = new Vector2(saveDashHorizontal * dashSpeed, saveDashVertical * dashSpeed);  // dash move
        } else {
            body.velocity = new Vector2(horizontal * playerSpeed, vertical * playerSpeed);  // basic movement
        }

        // rotates towards mouse 
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90);
    }

    void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.CompareTag("Enemy")) {
            if (!gracePeriodBool) {
                //playerHealth -= EnemyScript.enemy.Damage;
                gracePeriodBool = true;
                Debug.Log($"Damaged {playerHealth}");
                if (playerHealth <= 0) {
                    Destroy(gameObject);
                    playerDead = true;
                }
            }
        }
    }
}
