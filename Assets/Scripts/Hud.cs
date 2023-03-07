using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hud : MonoBehaviour
{

    [SerializeField] GameObject car;
    [SerializeField] TextMeshProUGUI packageDisplay;
    [SerializeField] TextMeshProUGUI timerDisplay;
    [SerializeField] TextMeshProUGUI gameOverDisplay;

    [SerializeField] float GameLength = 180f;
    [SerializeField] AudioClip warningSound;

    [SerializeField] AudioClip gameOverSound;
    private float timer;

    private bool warningDone = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameLength;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Delivery packageData = car.GetComponent<Delivery>();
        //TextMeshProUGUI packageDisplay = GetComponent<TextMeshProUGUI>();
        float dt = Time.deltaTime;
        packageDisplay.SetText(packageData.totalDelivered.ToString());

        if (timer > 0)
        {
            DisplayTime(timer);
        }
        else
        {
            timerDisplay.SetText("0:00.00");
            car.GetComponent<Driver>().driving = false;
            GetComponent<AudioSource>().PlayOneShot(gameOverSound);
            gameOverDisplay.alpha = 255;
        }
        timer -= dt;

        if (timer < 30f && !warningDone) {
            warningDone = true;
            GetComponent<AudioSource>().PlayOneShot(warningSound);
            timerDisplay.color = Color.red;
            
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 100;
        timerDisplay.SetText(string.Format("{0:0}:{1:00}:{2:00}", minutes, seconds, milliSeconds));
    }
}
