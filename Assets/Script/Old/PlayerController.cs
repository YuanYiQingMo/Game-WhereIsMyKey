using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void CheckInput()
    {
        if (true)
        {
            Move();
        }
        if(true)
        {
            Jump();
        }
    }
    private void Move()
    {

    }
    private void Jump(){
        
    }
}
