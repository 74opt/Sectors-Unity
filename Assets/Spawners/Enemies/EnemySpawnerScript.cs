using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {
    public Transform spawner1;
    public Transform spawner2;
    public Transform spawner3;
    public GameObject enemy;
    GameObject enemyInstance;
    //static int randomIndex;
    List<Transform> spawnerList;


    void Start() {
        spawnerList = new List<Transform>{spawner1, spawner2, spawner3};
        //Debug.Log($"List Length: {spawnerList.Count}");
        for (int i = 0; i < 4; i++) {
            InvokeRepeating("Spawn", Random.Range(0f, 8f), Random.Range(5f, 8f));
        }
    }

    void Spawn() {
        if (!PlayerScript.playerDead) {
            Transform spawner = spawnerList[Random.Range(0, spawnerList.Count)];
            enemyInstance = Instantiate(enemy, spawner.position, spawner.rotation);
        }
    }

    void Update() {
        
    }
}
