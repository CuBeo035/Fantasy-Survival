using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]
public class Char_Move : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    Vector3 Velocity;
    [Header("Movement Status")]
    public float speed;

    public float dashBoost = 2f;
    private float dashTime;
    public float DashTime;
    private bool once;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Velocity = new Vector3();
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        Velocity.x = Input.GetAxisRaw("Horizontal");
        Velocity.y = Input.GetAxisRaw("Vertical");
            transform.position += Velocity * speed * Time.deltaTime;
        ani.SetFloat("Move", Velocity.sqrMagnitude);
        if(Velocity .x != 0 ) 
        {
            if (Velocity.x == 1)
            {
                transform.localScale = new Vector3(10, 10, 10);
            }
            else if(Velocity.x == -1)
            {
                transform.localScale = new Vector3(-10, 10, 10);
            }
        }
        //dash
        Dash();
    }
    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dashTime <= 0 && Velocity.sqrMagnitude != 0)
        {
            ani.SetBool("Is_Dash", true);
            speed += dashBoost;
            dashTime = DashTime;
            once = true;
        }

        if (dashTime <= 0 && once)
        {
            ani.SetBool("Is_Dash", false);
            speed -= dashBoost;
            once = false;
        }
        else
        {
            dashTime -= Time.deltaTime;
        }
    }
}
