using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {
    public Transform spawner1;
    public Transform spawner2;
    public Transform spawner3;
    public Rigidbody2D enemy;
    Rigidbody2D enemyInstance;
    static int randomIndex;
    List<Transform> spawnerList;


    void Start() {
        spawnerList = new List<Transform>{spawner1, spawner2, spawner3};
        Debug.Log($"List Length: {spawnerList.Count}");
        InvokeRepeating("Spawn", 0.0f, Random.Range(5f, 8f));
    }

    void Spawn() {
        Transform spawner = spawnerList[Random.Range(0, spawnerList.Count)];
        enemyInstance = Instantiate(enemy, spawner.position, spawner.rotation);
    }

    void Update() {
        
    }
}
