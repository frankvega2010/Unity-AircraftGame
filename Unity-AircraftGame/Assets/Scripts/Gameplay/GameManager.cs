using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject panel;
    public Text finishText;
    public Text enemiesDestroyedText;
    public Text gameStartText;
    public float LoadSceneTime = 3;
    public float gameStartTime = 3;

    private Vector4 oldPanelColor;
    private LevelStatus levelStatus;
    private JetStatus playerStatus;
    private EnemiesDestroyed EnemiesDestroyedSingleton;
    private AircraftMovement playerAircraft;
    private AircraftCamera playerCamera;
    private float timerLoadScene;
    private float gameStartTimer;
    private bool gameStartSwitchOnce;
    private Image UIPanel;
    // Start is called before the first frame update
    private void Start()
    {
        oldPanelColor = new Vector4(0, 0, 0, 0.7f);
        playerStatus = JetStatus.Get();
        EnemiesDestroyedSingleton = EnemiesDestroyed.Get();
        playerAircraft = player.GetComponent<AircraftMovement>();
        playerCamera = player.GetComponent<AircraftCamera>();
        UIPanel = panel.GetComponent<Image>();
        enemiesDestroyedText.text = "";
        finishText.text = "";
        UIPanel.color = new Vector4(0, 0, 0, 0);
        Cursor.visible = false;
        levelStatus = GetComponent<LevelStatus>();
    }

    // Update is called once per frame
    private void Update()
    {
        gameStartTimer += Time.deltaTime;

        if(gameStartTimer > gameStartTime && !gameStartSwitchOnce)
        {
            gameStartText.text = "";
            gameStartSwitchOnce = true;
        }

        if (playerStatus.enemiesLeft <= 0)
        {
            playerWon();
        }

        if(playerStatus.fuel <= 0)
        {
            playerLost();
        }
    }

    private void playerWon()
    {
        playerAircraft.enabled = false;
        finishText.text = "You Won!";
        enemiesDestroyedText.text = "Enemies Destroyed (Total): " + EnemiesDestroyedSingleton.enemiesDestroyed.ToString();
        finishText.color = Color.green;
        timerLoadScene += Time.deltaTime;
        UIPanel.color = oldPanelColor;
        if (PlayerPrefs.GetInt("highscore") < EnemiesDestroyedSingleton.enemiesDestroyed)
        {
            PlayerPrefs.SetInt("highscore", EnemiesDestroyedSingleton.enemiesDestroyed);
            PlayerPrefs.Save();
        }

        if (timerLoadScene >= LoadSceneTime)
        {
            SceneManager.LoadScene(levelStatus.GetLevelName());
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    private void playerLost()
    {
        playerAircraft.enabled = false;
        finishText.text = "You Lost!";
        finishText.color = Color.red;
        enemiesDestroyedText.text = "Enemies Destroyed (Total): " + EnemiesDestroyedSingleton.enemiesDestroyed.ToString();
        timerLoadScene += Time.deltaTime;
        UIPanel.color = oldPanelColor;
        playerCamera.isTPCameraON = true;

        if (PlayerPrefs.GetInt("highscore") < EnemiesDestroyedSingleton.enemiesDestroyed)
        {
            PlayerPrefs.SetInt("highscore", EnemiesDestroyedSingleton.enemiesDestroyed);
            PlayerPrefs.Save();
        }

        if (timerLoadScene >= LoadSceneTime)
        {
            EnemiesDestroyedSingleton.enemiesDestroyed = 0;
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
