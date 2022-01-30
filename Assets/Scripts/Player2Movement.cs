using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    // Which player is currently the leader?
    public static int leader = 1;

    // Player 1 GameObject
    public GameObject player1;

    // Determines whether Player 2 can or cannot move
    public bool canMove;

    // Speed of the Player's movement
    public float speed;

    // The Rigidbody2D component for the Player Game Object
    private Rigidbody2D rb;

    // The change in position for the Player Game Object which is obtained from the input
    private Vector3 changeInPosition;

    // The Animator for the Player
    private Animator animator;

    // The SpriteRenderer for the Player
    private SpriteRenderer sr;

    // The target is the Game Object that Player 2 is going to follow
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {        
        // Set animator to the value of the Animator component for the Player Game Object
        animator = GetComponent<Animator>();

        // Set sr to the value of the SpriteRenderer component for the Player Game Object
        sr = GetComponent<SpriteRenderer>();

        // At the Start of the game, the player can move
        canMove = true;

        // Set rb to the value of the Rigidbody2D component for the Player Game Object
        rb = GetComponent<Rigidbody2D>();

        // Player 2 is going to follow the Player Game Object (Player 1)
        target = player1.GetComponent<Transform>();
    }


    public void followChar()
    {
        bool isMoving;
        if (Vector2.Distance(transform.position, target.position) > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        if(target.position.x - transform.position.x < 0.0f && !sr.flipX)
        {
            sr.flipX = true;
        }
        else
        {
            if(target.position.x - transform.position.x > 0.0f && sr.flipX)
            {
                sr.flipX = false;
            }
        }
        animator.SetFloat("moveX", target.position.x - transform.position.x);
        animator.SetFloat("moveY", target.position.y - transform.position.y);
        animator.SetBool("moving", isMoving);
    }

    // Update is called once per frame
    void Update()
    {
        // Prevent the character from moving all over the place when another character collides with it
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0.0f;

        if (Input.GetKeyDown(KeyCode.Y))
        {            
            if (canMove)
            {                
                canMove = false;
            }
            else
            {                
                canMove = true;
            }
        }

        if ((leader == 1 && gameObject.tag == "Player1") || (leader == 2 && gameObject.tag == "Player2") || !canMove)
        {
            return;
        }
        
        followChar();
    }
}
