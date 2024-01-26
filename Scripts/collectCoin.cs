using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectCoin : MonoBehaviour
{
    public int xPos;
    public int yPos;
    private int coinAmount;
    [SerializeField] public TMP_Text countText;
    void Start()
    {
        coinAmount = 0;
    }
    public void Update()
    {
        countText.text = coinAmount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Coin"))
        {
            coinAmount++;
            xPos = Random.Range(-30, 30);
            yPos = Random.Range(-24, 7);
            collider2D.transform.position = new Vector2(xPos, yPos);
        }
        if (collider2D.gameObject.CompareTag("Super Coin")) {
            coinAmount = coinAmount + 30;
            xPos = Random.Range(-30, 30);
            yPos = Random.Range(-24, 7);
            collider2D.transform.position = new Vector2(xPos, yPos);
        }
}
}
