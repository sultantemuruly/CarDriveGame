using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarShopElement : MonoBehaviour
{
    [SerializeField] private bool isInitialCar;
    public int unlockedValue;
    [SerializeField] private string unlockValueString;

    private void Awake()
    {
        unlockedValue = PlayerPrefs.GetInt(unlockValueString);

        if(isInitialCar) unlockedValue = 1;
    }

    public void OnCarUnlocked()
    {
        unlockedValue = 1;
        PlayerPrefs.SetInt(unlockValueString, 1);
    }
}
