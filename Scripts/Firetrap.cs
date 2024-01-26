using UnityEngine;
using System.Collections;

public class Firetrap : MonoBehaviour
{
    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;
    public AudioSource hurtsound;

    private bool triggered; //when the trap gets triggered
    private bool active; //when the trap is active and can hurt the player

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player 1" || collision.tag == "player 2")
        {
            if (!triggered)
                StartCoroutine(ActivateFiretrap());

            if (active)
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
    private IEnumerator ActivateFiretrap()
    {
        //turn the sprite red to notify the player and trigger the trap
        triggered = true;
        spriteRend.color = Color.red;

        //Wait for delay, activate trap, turn on animation, return color back to normal
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; //turn the sprite back to its initial color
        active = true;
        anim.SetBool("activated", true);

        //Wait until X seconds, deactivate trap and reset all variables and animator
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}