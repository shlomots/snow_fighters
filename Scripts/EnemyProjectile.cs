using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private BoxCollider2D coll;
    private bool hit;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        gameObject.SetActive(true);
        coll.enabled = true;
    }
    private void Update()
    {
       if (hit) return;
        float movementSpeed = speed;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player 1") | collision.gameObject.CompareTag("player 2"))
        {
            hit = true;
            base.OnTriggerEnter2D(collision); //Execute logic from parent script first
            coll.enabled = false;
            gameObject.SetActive(false); //When this hits any object deactivate arrow
        }
    }
   
}
