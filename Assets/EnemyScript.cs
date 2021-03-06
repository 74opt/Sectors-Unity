using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    //Rigidbody2D body;
    //private SpriteRenderer sRenderer;
    public Animator animator;
    public Transform playerTransform;
    public Transform enemyHealthBar;
    public static Sprite basic;
    public static Sprite tank;

    // Enemy spawers:
    List<Vector2> spawnerList;
    //public GameObject spawners;
    public Vector2 spawner1;
    public Vector2 spawner2;
    public Vector2 spawner3;

    // i have no clue why i separated this one
    GameObject enemyInstance;
    //public GameObject enemyBase;
    public Enemy enemy;

    // all the enemies
    public static Enemy basicEnemy = new Enemy("", new Vector3(3, 3, 3), 2, 10, 1.5f, "Chaser");
    public static Enemy tankEnemy = new Enemy("isTank", new Vector3(4, 4, 4), 4, 20, .7f, "Chaser");

    /* Note:
     * To make sure hitbox and scale match:
     * Vector3 (3, 3, 3) corresponds with size of (.1656, .1641)
     */

    /* Idea:
     * Move enemy spawner script code to here
     */

    /* Note:
     * remove spawner locations and just use Vector2?
     */

    void Start() {
        // setting up the spawners
        spawner1 = new Vector2(-4, 2);
        spawner2 = new Vector2(-3, -3);
        spawner3 = new Vector2(2, -3);

        // spawns enemies in a random location
        spawnerList = new List<Vector2> { spawner1, spawner2, spawner3 };
        //for (int i = 0; i < 2; i++) {
        //    InvokeRepeating("Spawn", 0.0f, Random.Range(5f, 8f));
        //}

        //sRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerTransform = GameObject.Find("Player").transform;

        // dict + spawn rates of enemies
        Dictionary<int, Enemy> enemyDict = new Dictionary<int, Enemy>() {
            {75, basicEnemy},
            {25, tankEnemy}
        };

        int chance = Random.Range(0, 100);

        foreach(var item in enemyDict) {
            //Debug.Log(chance);
            if (chance <= item.Key) {
                enemy = item.Value;
                break;
            } else {
                chance -= item.Key;
            }
        }

        gameObject.transform.localScale = enemy.Scale;

        if (enemy.EnemySprite != "") {
            animator.SetBool(enemy.EnemySprite, true);
        }

        //sRenderer.sprite = enemy.EnemySprite;
    }

    // method to spawn enemies in
    //void Spawn() {
    //    if (!PlayerScript.playerDead) {
    //        Vector2 spawner = spawnerList[Random.Range(0, spawnerList.Count)];
    //        enemyInstance = Instantiate(gameObject, spawner, new Quaternion(0, 0, 0, 0));
    //    }
    //}

    void Update() {
        if (enemy.Health <= 0) {
            Destroy(gameObject);
        }

        HealthBarScript.healthScale(enemy.Health, enemy.MaxHealth, enemyHealthBar);
        //enemyHealthBar.localScale = new Vector3(enemyHealth/enemyHealthConst, 1, 1);

        if (PlayerScript.playerDead) {
            playerTransform = null;
        }
    }

    void FixedUpdate() {
        if (!PlayerScript.playerDead) {
            // looks towards player
            transform.rotation = Quaternion.LookRotation(Vector3.forward, playerTransform.position - transform.position);

            // moves towards player
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, enemy.Speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player Projectile")) {
            enemy.Health -= ShootingScript.damage;
        }
    }
}

public struct Enemy{
    private string sprite;
    private Vector3 scale;
    private float damage;
    private float health;
    private float speed;
    private float maxHealth;
    private string ai;

    public string EnemySprite { get { return sprite; } }
    public Vector3 Scale { get { return scale; } set { scale = value; } }
    public float Damage { get { return damage; } set { damage = value; } }
    public float Health { get { return health; } set { health = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
    public float MaxHealth { get { return maxHealth; } }
    public string AI { get { return ai; } }

    public Enemy(string sprite, Vector3 scale, float damage, float health, float speed, string ai) {
        this.sprite = sprite;
        this.scale = scale;
        this.damage = damage;
        this.health = health;
        this.maxHealth = health;
        this.speed = speed;
        this.ai = ai;
    }

    //public Enemy DeepCopy() {
    //    Enemy other = (Enemy) this.MemberwiseClone();
    //    return other;
    //}
}
