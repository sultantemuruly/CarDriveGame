using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHolder : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;

    private void Start()
    {
        for(int i=0; i<cars.Length; i++)
        {
            cars[i].SetActive(false);
        }

        cars[GameManager.CarIndex].SetActive(true);
    }
}
