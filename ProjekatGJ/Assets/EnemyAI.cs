using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public GameObject player; // Player target
    public float chaseSpeed = 3; // chase speed
    public float idleSpeed = 1; // idle speed
    public float speedOfChangingTarget = 10;
    public float health = 100;
    public float damage = 3;
    private float distance;
    private float camHeight;
    private float camWidth;
    private float circleRadious = 2;
    Vector3 randomTarget;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start() {
        Camera cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        
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

        if(distance < 8) {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        } else {
            circleRadious = spriteRenderer.bounds.size.x / 2;
            Vector3 currentPos = transform.position;
            if (currentPos == randomTarget) {
                GenerateNewTarget();
            }
            
            float randomAngle = Mathf.Atan2(randomTarget.y, randomTarget.x) * Mathf.Rad2Deg;
            transform.position = Vector3.MoveTowards(currentPos, randomTarget, Time.deltaTime * idleSpeed); //movement from current position to target position
            transform.rotation = Quaternion.Euler(Vector3.forward * randomAngle);
        }
    }

    void OnCollisionStay2D() {
        GenerateNewTarget();
    }
    void GenerateNewTarget() {
        randomTarget = new Vector3(Random.Range(-(camWidth/2-circleRadious), camWidth/2-circleRadious), Random.Range(-(camHeight/2-circleRadious), camHeight/2-circleRadious), 0); //again provide random position in x and y
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponentInParent<PlayerController>();
        if (player != null)
        {
            player.lives -= 1;
            Debug.Log("OUCH2");
            
        }
    }
}
