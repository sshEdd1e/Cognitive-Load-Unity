using System.Buffers;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float countdownTime = 60f;

    private AudioSource audioSource;
    [SerializeField] private AudioClip warningBeep;
    [SerializeField] private AudioClip failureSound;
    private bool isCounting = false;
    private bool wonFlag = false;
    private float timeLeft;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timerText.gameObject.SetActive(false);
        startButton.onClick.AddListener(StartTimer);
    }

    private void StartTimer()
    {

        startButton.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);
        timeLeft = countdownTime;
        isCounting = true;
        StartCoroutine(TimerRoutine());
    }

    private IEnumerator TimerRoutine()
    {
        while (isCounting && timeLeft > 0)
        {
            if (timeLeft <= 10)
            {
                audioSource.PlayOneShot(warningBeep);
            }
            yield return new WaitForSeconds(1f);

        }

        if (!wonFlag)
        {
            timerText.text = "00:00:000";
            yield return new WaitForSeconds(1);
            isCounting = false;
            timerText.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isCounting && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerUI();
        }
        else if (timeLeft <= 0 && isCounting)
        {
            timeLeft = 0;
            isCounting = false;
            UpdateTimerUI();
            audioSource.PlayOneShot(failureSound);
        }
    }

    private void UpdateTimerUI()
    {
        
            int minutes = Mathf.FloorToInt(timeLeft / 60);
            int seconds = Mathf.FloorToInt(timeLeft % 60);
            int milliseconds = Mathf.FloorToInt((timeLeft % 1) * 1000);

            timerText.text = $"{minutes:D2}:{seconds:D2}:{milliseconds:D3}";
    }
    public void StopCounting()
    {
        isCounting = false;
        wonFlag = true; 
        yield return new WaitForSeconds(3);
        timerText.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(true);
    }
}
