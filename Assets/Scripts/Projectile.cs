using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocity;

    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x < -13)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.left * velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && transform.position.x > -11)
        {
            GameController.AddScore();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
