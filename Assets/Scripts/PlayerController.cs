using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    [Header("Player config")]
    [SerializeField] private float speed;
    [SerializeField] private Transform groundDetector;
    
    [Space]
    [Header("Jump config")]
    [SerializeField] private LayerMask _layerGround;
    [SerializeField] [Range(0, 2)] private float _maxDistance;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpTime;
    [SerializeField] private float _jumpTimeCounter;
    [SerializeField] private bool _isJumping;
    private bool _isGrounded;

    [Space]
    [Header("UI Max height")]
    private float _startPositionY;
    private float _maxHeight;
    [SerializeField] private Text txtHeight;
    [SerializeField] private Transform  trVerticalBar;
    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(groundDetector.position, Vector2.down * _maxDistance);
    }

    void Start()
    {
        _startPositionY = transform.position.y;
        _maxHeight = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       SetMaxHeight();


        //Move x axis
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        
        //Ground detector
        RaycastHit2D hit = Physics2D.Raycast(groundDetector.position, Vector2.down, _maxDistance, _layerGround);

        _isGrounded = (hit.collider) ? true : false;
        
        //Jump
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            //rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
            _jumpTimeCounter = _jumpTime;
            _isJumping = true;
        }
        
        if (Input.GetKey(KeyCode.Space)  && _isJumping)
        {
            
            if (_jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
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

    private void SetMaxHeight()
    {
        float actualHeight = (transform.position.y - _startPositionY);
        
        SetBarHeight(actualHeight);
        
        if (actualHeight > _maxHeight)
        {
            _maxHeight = actualHeight;
            
            txtHeight.text = _maxHeight.ToString("F")+"m";
        }
    }

    private void SetBarHeight(float height)
    {
        Vector3 newScale = trVerticalBar.localScale;
        newScale.y = height;
        trVerticalBar.localScale = newScale;
    }




}
