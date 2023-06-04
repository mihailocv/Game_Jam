using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public AnimationClip damagedAnimation;
    public GameObject player; // Player target
    public float chaseSpeed = 3; // chase speed
    public float idleSpeed = 1; // idle speed
    public float speedOfChangingTarget = 10;
    public float health = 100;
    public float damage = 3;
    private float distance;
    private float camHeight;
    private float camWidth;

    // Start is called before the first frame update
    void Start() {

        Camera cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
                
        InvokeRepeating("GenerateNewTarget", 0f, speedOfChangingTarget);
    }

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var egg = other.GetComponentInParent<Egg>();
        var collisionPlayer = other.GetComponentInParent<PlayerController>();

        if (collisionPlayer != null) 
        {
            Score.score += 1;
        }

        if (egg != null)
        {
            egg.lives -= 1;
            Debug.Log("OUCH");
            Time.timeScale = 0;

        }
    }
    

}
