using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    private PrometeoCarController prometeoCarController;

    private void Start()
    {
        prometeoCarController = GetComponent<PrometeoCarController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            SoundManager.OnFinishSound();
            prometeoCarController.isActive = false;
            GameManager.OnLevelCompleted();

            return;
        }

        if(other.CompareTag("Coin"))
        {
            SoundManager.OnCoinSound();
            GameManager.SetCoin(10);
            Destroy(other.gameObject);
        }
    }
}
