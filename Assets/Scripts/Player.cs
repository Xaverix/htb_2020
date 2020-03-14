using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public GameObject projectile;
    
    private Rigidbody2D _rb;

    private float _shootCooldown = 0.6f;
    private float _shootT;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        _rb.velocity = playerInput * playerSpeed;
    }

    private void Update()
    {
        _shootT += Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (_shootT >= _shootCooldown)
            {
                Shoot();
                _shootT = 0f;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, transform.position + new Vector3(-0.5f, 0f, 0f), Quaternion.identity);
    }
}
