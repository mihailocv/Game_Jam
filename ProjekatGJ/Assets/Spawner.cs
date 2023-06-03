    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
     
    public class spawn : MonoBehaviour
    {
        public GameObject enemyFishType1;
        public GameObject enemyFishType2;
        public GameObject enemyFishType3;
        public float timeBtwSpawn = 10;
        public float startTimeBtwSpawn = 5;
        public float decreaseTime;
        public float minTime = 0.65f;
        public int spawnSide;
        private GameObject enemyToSpawn;

        void Start()
        {
            spawnSide = Random.Range(0, 4);
            NewEnemy();
        }
     
        void Update()
        {
            if(timeBtwSpawn <= 0) {
                if(spawnSide == 0) {
                    Instantiate(enemyToSpawn, new Vector3(-10f, Random.Range(-10f, 10f), 0f), Quaternion.identity);
                    spawnSide = Random.Range(0, 4);
                    NewEnemy();
                }
                else if(spawnSide == 1) {
                    Instantiate(enemyToSpawn, new Vector3(10f, Random.Range(-10f, 10f), 0f), Quaternion.identity);
                    spawnSide = Random.Range(0, 4);
                    NewEnemy();
                }
                else if(spawnSide == 2) {
                    Instantiate(enemyToSpawn, new Vector3(Random.Range(-8f, 8f), 10f, 0f), Quaternion.identity);
                    spawnSide = Random.Range(0, 4);
                    NewEnemy();              
                }
                else if(spawnSide == 3) {
                    Instantiate(enemyToSpawn, new Vector3(Random.Range(-8f, 8f), -10f, 0f), Quaternion.identity);
                    spawnSide = Random.Range(0, 4);
                    NewEnemy();
                }
                timeBtwSpawn = startTimeBtwSpawn;
            } else {
                timeBtwSpawn -= Time.deltaTime;
            }
        }

        void NewEnemy() {
            int randEnemy = Random.Range(0, 3);
            
            if(randEnemy == 1) {
                enemyToSpawn = enemyFishType1;
            }
            else if(randEnemy == 2) {
                enemyToSpawn = enemyFishType2;
            }
            else if(randEnemy == 3) {
                enemyToSpawn = enemyFishType3;
            }
            else {
                enemyToSpawn = enemyFishType1;
            }

        }
    }