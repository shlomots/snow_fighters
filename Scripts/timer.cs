using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    private float startTime;
    private bool finshed = false;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (!finshed)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;
            if (t >= 60)
            {
                finshed = true;
                timerText.text = "Time's up!";
            }
        }
    }
}
