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
    public float LoadSceneTime = 3;

    private Vector4 oldPanelColor;
    private JetStatus playerStatus;
    private EnemiesDestroyed EnemiesDestroyedSingleton;
    private AircraftMovement playerAircraft;
    private float timerLoadScene;
    private Image UIPanel;
    // Start is called before the first frame update
    private void Start()
    {
        oldPanelColor = new Vector4(0, 0, 0, 0.7f);
        playerStatus = JetStatus.Get();
        EnemiesDestroyedSingleton = EnemiesDestroyed.Get();
        playerAircraft = player.GetComponent<AircraftMovement>();
        UIPanel = panel.GetComponent<Image>();
        enemiesDestroyedText.text = "";
        finishText.text = "";
        UIPanel.color = new Vector4(0, 0, 0, 0);
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(playerStatus.enemiesLeft <= 0)
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
        PlayerPrefs.SetInt("highscore", EnemiesDestroyedSingleton.enemiesDestroyed);

        if (timerLoadScene >= LoadSceneTime)
        {
            SceneManager.LoadScene("LevelTemplate");
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
        PlayerPrefs.SetInt("highscore", EnemiesDestroyedSingleton.enemiesDestroyed);

        if (timerLoadScene >= LoadSceneTime)
        {
            EnemiesDestroyedSingleton.enemiesDestroyed = 0;
            SceneManager.LoadScene("LevelTemplate");
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
