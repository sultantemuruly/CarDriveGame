using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameObject countDown;
    [SerializeField] private PrometeoCarController[] prometeoCarControllers;
    [SerializeField] private TextMeshProUGUI timeText;
    private float timeLeft = 59;

    private bool isStarted = false;

    private void Start()
    {
        Invoke("OnStart", 4f);
    }

    private void OnStart()
    {
        isStarted = true;
        prometeoCarControllers[GameManager.CarIndex].isActive = true;
        countDown.SetActive(false);
    }

    private void Update()
    {
        if(!isStarted) return;

        if(GameManager.isLevelCompleted || GameManager.isLevelFailed) return;

        timeLeft -= Time.deltaTime;
        timeText.text = "Sec:" + timeLeft.ToString("F2");

        if(timeLeft <= 0)
        {
            prometeoCarControllers[GameManager.CarIndex].isActive = false;
            GameManager.OnLevelFailed();

            return;
        }
    } 
}
