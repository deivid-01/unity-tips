using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]  private int speed;
    [SerializeField]  private int jumpSpeed;
    [SerializeField]  private Transform groundDetector;
    [SerializeField]  private LayerMask layerGround;
    [SerializeField]  private float  maximeInTheAir;
    private float  timeInTheAir;

    private Rigidbody2D rb;

    void Start()
    {
    
        rb = GetComponent<Rigidbody2D>();
    }




    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*speed,rb.velocity.y);

        RaycastHit2D hit = Physics2D.Raycast(groundDetector.position,Vector3.down, 0.1f, layerGround);

        if (hit == true)
        {
            timeInTheAir = 0;
        }
        else
        {
            timeInTheAir += Time.deltaTime;
        }



        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (hit == true)
            {

                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * jumpSpeed);
            }
            else
            {
                if (timeInTheAir < 0.25f)
                { 
                    rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * jumpSpeed);
                }
            }
        }
    

       


    }

    //Contanst rate
   

}
