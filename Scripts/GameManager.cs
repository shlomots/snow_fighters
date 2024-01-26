using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public int p1life;
    public int p2life;

    public Boolean p1Protected = false;
    
    public Boolean p2Protected = false;

    public Boolean p1HasSuperShot = false;
   
    public Boolean p2HasSuperShot = false;
    public GameObject[] p1Sticks;
    public GameObject[] p2Sticks;



    [SerializeField] public AudioSource hurtsound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (p1life <= 0)
        {
            //player1.SetActive(false);
            StartCoroutine(Freeze(player1));

        }

        if (p2life <= 0)
        {
            //player2.SetActive(false);
            StartCoroutine(Freeze(player2));
        }
    }

    public void HurtP1()
    {
        if (p1life > 0)
        {
            if (p1Protected == false)
            {
                if (p2HasSuperShot)
                {
                    p1life = 0;
                }
                else
                {
                    p1life -= 1;
                }

            }



            //the idea is to cheack after each shot, which life sticks should remain active and which should be deactivated.
            for (int i = 0; i < p1Sticks.Length; i++)
            {
                if (p1life > i)
                {
                    p1Sticks[i].SetActive(true);
                }
                else
                {
                    p1Sticks[i].SetActive(false);
                }

            }
            hurtsound.Play();
        }

    }

    public void HurtP2()
    {

        if (p2life > 0)
        {
            if (p2Protected == false)
            {
                if (p1HasSuperShot)
                {
                    p2life = 0;
                }
                else
                {
                    p2life -= 1;
                }

            }


            for (int i = 0; i < p2Sticks.Length; i++)
            {
                if (p2life > i)
                {
                    p2Sticks[i].SetActive(true);
                }
                else
                {
                    p2Sticks[i].SetActive(false);
                }
            }
            hurtsound.Play();
        }

    }

    public void HurtP1ByObsticle()
    {
        if (p1life > 0)
        {
            if (p1Protected == false)
            {
                p1life -= 1;
            }
        }

        //the idea is to cheack after each shot, which life sticks should remain active and which should be deactivated.
        for (int i = 0; i < p1Sticks.Length; i++)
        {
            if (p1life > i)
            {
                p1Sticks[i].SetActive(true);
            }
            else
            {
                p1Sticks[i].SetActive(false);
            }

        }
        hurtsound.Play();
    }

    public void HurtP2ByObsticle()
    {
        if (p2life > 0)
        {
            if (p2Protected == false)
            {
                p2life -= 1;
            }
        }

        //the idea is to cheack after each shot, which life sticks should remain active and which should be deactivated.
        for (int i = 0; i < p2Sticks.Length; i++)
        {
            if (p2life > i)
            {
                p2Sticks[i].SetActive(true);
            }
            else
            {
                p2Sticks[i].SetActive(false);
            }

        }
        hurtsound.Play();
    }




    IEnumerator Freeze(GameObject player)
    {
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(3);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        //player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, player.GetComponent<Rigidbody2D>().velocity.y);
        //player.GetComponent<Rigidbody2D>().transform.localScale = new Vector2(3, 3);
        if (player.tag == "player 1")
        {
            p1life = 3;
            for (int i = 0; i < p1Sticks.Length; i++)
            {
                p1Sticks[i].SetActive(true);
            }
        }
        if (player.tag == "player 2")
        {
            p2life = 3;
            for (int i = 0; i < p2Sticks.Length; i++)
            {
                p2Sticks[i].SetActive(true);
            }
        }

    }
}
