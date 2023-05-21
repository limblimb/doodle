using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    float hInput = 0;
    Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        /*GameObject buttonLeft = GameObject.Find("Button Left");
        GameObject buttonRight = GameObject.Find("Button Right");*/
    }

    // Update is called once per frame
    void Update()
    {
        Move(hInput);
    }

    void Move(float horizontalInput)
    {
        Vector2 moveVel = player.velocity;
        moveVel.x = horizontalInput * moveSpeed;
        player.velocity = moveVel;
    }

    public void StartMoving(float horizontalInput)
    {
        hInput = horizontalInput;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
    }

    /*public void MoveLeft()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);              
    }
    
    public void MoveRight()
    {
        
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
    */
    
}
