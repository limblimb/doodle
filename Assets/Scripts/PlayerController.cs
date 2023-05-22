using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    float hInput = 0;
    Rigidbody2D player;
    private PlatformGenerator platformPooler;
    [HideInInspector] public static bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        platformPooler = FindAnyObjectByType<PlatformGenerator>();
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(hInput);
    }

    void Move(float horizontalInput)
    {
        Vector2 moveVel = player.velocity;
        moveVel.x = horizontalInput * moveSpeed * Time.fixedDeltaTime;
        player.velocity = moveVel;
    }

    public void StartMoving(float horizontalInput)
    {
        hInput = horizontalInput;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") && player.velocity.y <= 0.5f)
        {
            Jump();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cracking Platform") && player.velocity.y <= 0.5f)
        {
            platformPooler.ReturnPlatformToPool(collision.gameObject);
            platformPooler.MakeAnotherOne();
        }
        if (collision.gameObject.CompareTag("Dead Zone"))
        {
            isAlive = false;
            Debug.Log("ъ слеп");
        }
    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
    }

    
}
