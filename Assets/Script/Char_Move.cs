using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Char_Move : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody2D rb;
    Vector2 move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputMove();
    }

    void InputMove()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
    }
}
