using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private static int currentLevel;
    private static string LevelKey = "CurrentLevel";
    
    [SerializeField] private GameObject[] levels;
    private static GameObject[] Levels;

    //coin settings
    [Header("Coin Settings")]
    [SerializeField] private TextMeshProUGUI coinText;
    private static TextMeshProUGUI CoinText;
    public static int coinCount {get; private set; }
    private static string CoinKey = "CoinCount";

    //ui
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject levelCanvas;
    private static GameObject LevelCanvas;
    [SerializeField] private GameObject finishCanvas;
    private static GameObject FinishCanvas;
    [SerializeField] private GameObject failCanvas;
    private static GameObject FailCanvas;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button homeButton;

    //car settings
    public static int CarIndex;
    private static string CarKey = "CarIndex";

    public static bool isLevelCompleted;
    public static bool isLevelFailed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Levels = levels;

        nextButton.onClick.AddListener(NextButton);
        homeButton.onClick.AddListener(HomeButton);
        
        LevelCanvas = levelCanvas;
        FinishCanvas = finishCanvas;
        FailCanvas = failCanvas;

        CarIndex = PlayerPrefs.GetInt(CarKey);

        DataInit();
    }

    private void DataInit()
    {
        currentLevel = PlayerPrefs.GetInt(LevelKey);
        levelText.text = "Level " + (currentLevel+1).ToString();

        CoinText = coinText;
        coinCount = PlayerPrefs.GetInt(CoinKey);
        CoinText.text = coinCount.ToString();
    }

    public static void OnStart()
    {
        LevelCanvas.SetActive(true);
        SceneManager.LoadScene(1);

        Levels[currentLevel].SetActive(true);
    }

    public static void OnLevelCompleted()
    {
        PlayerPrefs.SetInt(CoinKey, coinCount);
        
        isLevelCompleted = true;

        currentLevel+=1;
        if(currentLevel >= Levels.Length) currentLevel = 0;
        PlayerPrefs.SetInt(LevelKey, currentLevel);

        LevelCanvas.SetActive(false);
        FinishCanvas.SetActive(true);
    }

    public static void OnLevelFailed()
    {
        isLevelFailed = true;

        LevelCanvas.SetActive(false);
        FailCanvas.SetActive(true);
    }

    private void NextButton()
    {
        for(int i=0; i< Levels.Length; i++)
        {
            Levels[i].SetActive(false);
        }

        Levels[currentLevel].SetActive(true);

        DataInit();
        SceneManager.LoadScene(1);

        FinishCanvas.SetActive(false);
        LevelCanvas.SetActive(true);
    }

    private void HomeButton()
    {
        for(int i=0; i< Levels.Length; i++)
        {
            Levels[i].SetActive(false);
        }

        DataInit();
        SceneManager.LoadScene(0);

        FinishCanvas.SetActive(false);
    }

    public static void SetCoin(int addCoin)
    {
        coinCount += addCoin;
        CoinText.text = coinCount.ToString();
    }

    public static void SetCarIndex(int val)
    {
        CarIndex = val;
        PlayerPrefs.SetInt(CarKey, CarIndex);
    }
}
