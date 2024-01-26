using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowballMovement : MonoBehaviour

{
    public float ballspeed;

    private Rigidbody2D theRB;
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(ballspeed * transform.localScale.x, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player 1")
        {
            FindObjectOfType<GameManager>().HurtP1();
            Destroy(this.gameObject);
        }

        if (other.tag == "player 2")
        {
            FindObjectOfType<GameManager>().HurtP2();
            Destroy(this.gameObject);
        }
        
    }
}
