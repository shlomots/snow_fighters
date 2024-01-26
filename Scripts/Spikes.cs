using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] public AudioSource hurtsound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player 1")
        {
            FindObjectOfType<GameManager>().HurtP1ByObsticle();
            hurtsound.Play();
        }
        else if (collision.tag == "player 2")
        {
            FindObjectOfType<GameManager>().HurtP2ByObsticle();
            hurtsound.Play();
        }
    }
}
