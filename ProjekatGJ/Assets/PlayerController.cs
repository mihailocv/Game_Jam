using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    public float rotateSpeed =  0.1f;
    public int lives = 1;
    Rigidbody2D rb;
    Vector2 position = new Vector2(0f, 0f);
     

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        transform.rotation = Quaternion.LookRotation(Vector3.back, mousePosition);
        // if (transform.rotation.eulerAngles.z < 0)
        // {
        //     Debug.Log ("do something special");
        // }
        if (lives == 0)
        {
            Debug.Log("Game Over");
        };

    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }
}

