using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 mousePosition;
    Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private Sprite newSprite;
    [SerializeField] private AnimationClip newAnimation;
    
    public float moveSpeed = 0.1f;
    public float rotateSpeed =  0.1f;
    public int lives = 1;
    
    Vector2 position = new Vector2(0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        transform.rotation = Quaternion.LookRotation(Vector3.back, mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponentInParent<EnemyAI>();
        if (enemy != null)
        {
            spriteRenderer.sprite = newSprite;
            animator.SetTrigger("attack_trigger");
            // other.attachedRigidbody.useGravity = true;
            enemy.Die();
            Debug.Log("Append Score");

        }
    }

}

