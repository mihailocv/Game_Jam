    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
     
    public class spawn : MonoBehaviour
    {
        public GameObject enemyFishType1;
        public GameObject enemyFishType2;
        public GameObject enemyFishType3;
        public GameObject enemyFishType4;
        public float timeBtwSpawn = 2;
        public float startTimeBtwSpawn = 5;
        public float decreaseTime;
        public float minTime = 0.65f;
        public int spawnSide;
        private GameObject enemyToSpawn;
        float counter = 0;
        public float counterStep = 0.1f;

        void Start()
        {
            spawnSide = Random.Range(0, 4);
            NewEnemy();
        }
     
        void Update()
        {
            counter += Time.deltaTime;

            if (counter >= 5 && startTimeBtwSpawn > 0.2) {
                counter = 0;
                DecreaseTimeBtwSpawn();
                    
            } 
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

        void DecreaseTimeBtwSpawn() {
            startTimeBtwSpawn -= counterStep;
        }

        void NewEnemy() {
            int randEnemy = Random.Range(0, 5);
            
            if(randEnemy == 1) {
                enemyToSpawn = enemyFishType1;
            }
            else if(randEnemy == 2) {
                enemyToSpawn = enemyFishType2;
            }
            else if(randEnemy == 3) {
                enemyToSpawn = enemyFishType3;
            }
            else if(randEnemy == 4) {
                enemyToSpawn = enemyFishType4;
            }
            else {
                enemyToSpawn = enemyFishType1;
            }

        }
    }
