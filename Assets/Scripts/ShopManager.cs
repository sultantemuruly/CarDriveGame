using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private int currentIndex;
    [SerializeField] private GameObject[] cars;

    [SerializeField] private List<int> unlockedCarValues = new List<int>();
    [SerializeField] private int[] price;

    [SerializeField] private Button rightButton;
    [SerializeField] private Button leftButton;

    [SerializeField] private Button buyButton;
    [SerializeField] private Button selectButton;

    [SerializeField] private TextMeshProUGUI priceText;

    private void Start()
    {
        for(int i=0; i<cars.Length; i++)
        {
            unlockedCarValues.Add(cars[i].GetComponent<CarShopElement>().unlockedValue);
            cars[i].SetActive(false);
        }
        
        currentIndex = GameManager.CarIndex;
        cars[currentIndex].SetActive(true);

        rightButton.onClick.AddListener(OnRightButtonClick);
        leftButton.onClick.AddListener(OnLeftButtonClick);

        buyButton.onClick.AddListener(OnBuyCar);
        selectButton.onClick.AddListener(OnSelectCar);
    }

    private void OnRightButtonClick()
    {
        currentIndex += 1;

        if(currentIndex >= cars.Length)
        {
            currentIndex = 0;
        }

        for(int i=0; i<cars.Length; i++)
        {
            cars[i].SetActive(false);
        }

        cars[currentIndex].SetActive(true);

        if(unlockedCarValues[currentIndex] == 1)
        {
            buyButton.gameObject.SetActive(false);

            if(GameManager.CarIndex == currentIndex)
                selectButton.gameObject.SetActive(false);
            else 
                selectButton.gameObject.SetActive(true);
        }
        else
        {
            priceText.text = price[currentIndex].ToString() + "$";
            buyButton.gameObject.SetActive(true);
            selectButton.gameObject.SetActive(false);
        }
    }

    private void OnLeftButtonClick()
    {
        currentIndex -= 1;

        if(currentIndex < 0)
        {
            currentIndex = cars.Length - 1;
        }

        for(int i=0; i<cars.Length; i++)
        {
            cars[i].SetActive(false);
        }

        cars[currentIndex].SetActive(true);

        if(unlockedCarValues[currentIndex] == 1)
        {
            buyButton.gameObject.SetActive(false);

            if(GameManager.CarIndex == currentIndex)
                selectButton.gameObject.SetActive(false);
            else 
                selectButton.gameObject.SetActive(true);
        }
        else
        {
            priceText.text = price[currentIndex].ToString() + "$";
            buyButton.gameObject.SetActive(true);
            selectButton.gameObject.SetActive(false);
        }
    }

    private void OnBuyCar()
    {
        if(GameManager.coinCount >= price[currentIndex])
        {
            GameManager.SetCarIndex(currentIndex);
            GameManager.SetCoin(price[currentIndex] * (-1));

            cars[currentIndex].GetComponent<CarShopElement>().OnCarUnlocked();
            unlockedCarValues[currentIndex] = 1;

            buyButton.gameObject.SetActive(false);
        }
    }

    private void OnSelectCar()
    {
        GameManager.SetCarIndex(currentIndex);
        
        buyButton.gameObject.SetActive(false);
        selectButton.gameObject.SetActive(false);
    }
}
