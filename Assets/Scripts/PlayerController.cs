using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float jumpForce = 60f;

    private Rigidbody2D rb2d;
    private float horizontalMove;
    private float verticalMove;
    private bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (horizontalMove > 0.1f || horizontalMove < -0.1f)
        {
            rb2d.AddForce(new Vector2(horizontalMove * movementSpeed, 0f), ForceMode2D.Impulse);
        }

        if ((verticalMove > 0.1f) && !isJump)
        {
            rb2d.AddForce(new Vector2(0, verticalMove * jumpForce));
        }

        if(verticalMove < -0.1f && isJump) {
            rb2d.AddForce(new Vector2(0, verticalMove * jumpForce));
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Ground") {
            isJump = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Ground") {
            isJump = true;
        }
    }
}
