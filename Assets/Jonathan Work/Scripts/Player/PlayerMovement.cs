using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera sceneCamera;
    public float moveSpeed;
    Rigidbody2D rb;
    private Vector2 mousePos;

    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 moveDir;

    public GameObject fireballPrefab;
    public Transform firePoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }

    // WASD movement
    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        moveDir = new Vector2(moveX, moveY).normalized;
        mousePos = sceneCamera.ScreenToWorldPoint(Input.mousePosition);


        // stores last input value before movement stops so player faces correct direction
        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
        }

        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
        }
    }

    // Player speed
    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }


    void Shoot()
    {   
        
        Vector2 firePointPosition = firePoint.position;
        Vector2 direction = (mousePos - firePointPosition).normalized;

        GameObject fireball = Instantiate(fireballPrefab, firePointPosition, Quaternion.identity);
        fireball.GetComponent<Fireball>().Initialize(direction);
    }
}
