using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private Transform groundDetector;
    [SerializeField] private LayerMask _layerGround;
    [SerializeField] [Range(0, 2)] private float _maxDistance;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpTime;
    [SerializeField] private float _jumpTimeCounter;
    [SerializeField] private bool _isJumping;
    private float _moveInput;
    private bool _isGrounded;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(groundDetector.position, Vector2.down * _maxDistance);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
    
        
        
        //Move x axis
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        
        RaycastHit2D hit = Physics2D.Raycast(groundDetector.position, Vector2.down, _maxDistance, _layerGround);

        _isGrounded = (hit.collider) ? true : false;
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            //Jump
            _isJumping = true;
            _jumpTimeCounter = _jumpTime;
         
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (_jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x,_jumpForce);
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isJumping = false;
        }

    }


}
