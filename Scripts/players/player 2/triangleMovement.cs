
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triangleMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] public Transform groundCheckPoint;
    [SerializeField] public float groundCheckRadius;
    [SerializeField] public LayerMask WhatIsGround;
    private bool grounded;
    public Transform throwPoint;
    public GameObject snowball;
    public KeyCode right;
    public KeyCode left;
    public KeyCode jump;
    public KeyCode throwBall;
    public AudioSource jumpSound;
    public AudioSource throwSound;
    int xPos;
    int yPos;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        body.transform.localScale = new Vector2(3, 3);
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, WhatIsGround);
        
            //turn left and right.
            if (Input.GetKey(right))
            {
                body.velocity = new Vector2(speed, body.velocity.y);
                transform.localScale = new Vector2(3, 3);
            }

            else if (Input.GetKey(left))
            {
                body.velocity = new Vector2(-speed, body.velocity.y);
                transform.localScale = new Vector2(-3, 3);
            }
            else
            {
                body.velocity = new Vector2(0, body.velocity.y);
            }

            if (Input.GetKey(jump))
                Jump1();

            if (Input.GetKeyDown(throwBall))
            {
                GameObject ballClone = (GameObject)Instantiate(snowball, throwPoint.position, throwPoint.rotation);
                ballClone.transform.localScale = transform.localScale;
                throwSound.Play();

            }
            if (body.velocity.x < 0)
            {
                transform.localScale = new Vector2(-3, 3);
            }
            else if (body.velocity.x > 0)
            {
                transform.localScale = new Vector2(3, 3);
            }
        

        anim.SetFloat("Speed", Mathf.Abs(body.velocity.x));
        anim.SetBool("Grounded", grounded);

        IEnumerator FreezeCharacter(float duration)
        {
            // Disable the character's movement and other actions
            GetComponent<CharacterController>().enabled = false;

            // Wait for the specified duration
            yield return new WaitForSeconds(duration);

            // Enable the character's movement and other actions
            GetComponent<CharacterController>().enabled = true;
        }







        //   anim.SetBool("run", Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D));//if something is pressed, you should run.
    }

    private void Jump1()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
        jumpSound.Play();
    }

    IEnumerator OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("speed coin"))
        {
            collider2D.transform.position = new Vector2(1000, 1000);
            speed = 20;
            int xPos;
            int yPos;
            xPos = Random.Range(12, 27);
            yPos = -13;
            //make coin disapear
            yield return new WaitForSeconds(10);
            collider2D.transform.position = new Vector2(xPos, yPos);
            speed = 12;
        }

        if (collider2D.gameObject.CompareTag("shield coin"))
        {
            collider2D.transform.position = new Vector2(1000, 1000);//make coin disapear    
            int xPos;
            int yPos;
            FindObjectOfType<GameManager>().p2Protected = true;
            xPos = Random.Range(-27, -23);
            yPos = -23;  
            yield return new WaitForSeconds(10);
            FindObjectOfType<GameManager>().p2Protected = false;
            collider2D.transform.position = new Vector2(xPos, yPos);//make coin reapear   
        }

        if (collider2D.gameObject.CompareTag("super shot coin"))
        {
            collider2D.transform.position = new Vector2(1000, 1000);//make coin disapear
            FindObjectOfType<GameManager>().p2HasSuperShot = true;
            xPos = Random.Range(8, 15);
            yPos = 1;
    
            yield return new WaitForSeconds(10);
            FindObjectOfType<GameManager>().p2HasSuperShot = false;
            collider2D.transform.position = new Vector2(xPos, yPos);
            
        }


    }
}