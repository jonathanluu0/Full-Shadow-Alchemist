using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float maxDistance;
    public GameObject explosionEffect;

    private Vector2 startPosition;
    private Vector2 direction;


    void Start()
    {
        startPosition = transform.position;
    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction.normalized;
    }

    void Update()
    {
        // Move the fireball
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the fireball has reached its maximum distance
        if (Vector2.Distance(startPosition, transform.position) >= maxDistance)
        {
            Explode();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check for collision with other objects
        Explode();
    }

    void Explode()
    {
        // Instantiate explosion effect
        if (explosionEffect != null)
        {
            //Instantiate(explosionEffect, transform.position, transform.rotation);
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            // Rotate the explosion effect by 90 degrees around the Z-axis
            explosion.transform.Rotate(0, 0, -90);
        }

        // Destroy the fireball
        Destroy(gameObject);
    }


}
