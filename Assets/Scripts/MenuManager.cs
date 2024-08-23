using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingCanvas;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button settingsCloseButton;
    [SerializeField] private Button startButton;
    
    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        settingsButton.onClick.AddListener(OpenSettingsPanel);
        settingsCloseButton.onClick.AddListener(CloseSettingsPanel);
    }

    private void OnStartButtonClick()
    {
        loadingCanvas.SetActive(true);
        Invoke("OnStart", 2f);
    }

    private void OnStart()
    {
        GameManager.OnStart();
    }

    private void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    private void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
}
