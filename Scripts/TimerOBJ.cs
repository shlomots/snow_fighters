using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
public class TimerOBJ : MonoBehaviour
{
    [SerializeField] public gameOverScript gameOver;
    [Header("Timer UI references :")]
    [SerializeField] private Image uiFillImage;
    [SerializeField] private Text uiText;
    [SerializeField] public TMP_Text countTextplayer1;
    [SerializeField] public TMP_Text countTextplayer2;
    public int Duration { get; private set; }

    private int remainingDuration;

    private void Awake()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        uiText.text = "00:00";
        uiFillImage.fillAmount = 0f;
        Duration = remainingDuration = 0;
    }

    public TimerOBJ SetDuration(int seconds)
    {
        Duration = remainingDuration = seconds;
        return this;
    }


    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration > 0)
        {
            UpdateUI(remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        End();
    }

    private void UpdateUI(int seconds)
    {
        uiText.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);
        uiFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }

    public void End()
    {
        ResetTimer();
        gameOver.setup(countTextplayer1.text, countTextplayer2.text);
    }


    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}