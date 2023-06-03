using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    public float rotateSpeed =  0.1f;
    Rigidbody2D rb;
    Vector2 position = new Vector2(0f, 0f);
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }

        if(attacking) {
            timer += Time.deltaTime;

            if(timer >= timeToAttack) {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        transform.rotation = Quaternion.LookRotation(Vector3.back, mousePosition);
        if (transform.rotation.eulerAngles.z < 0)
        {
            Debug.Log ("do something special");
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }

    private void Attack() {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}

