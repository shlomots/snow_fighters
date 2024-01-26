using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] TimerOBJ timer1;
    [SerializeField] public settingsMenu settingsMenu;
    void Start()
    {
        timer1.SetDuration(settingsMenu.durationInSec).Begin();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
