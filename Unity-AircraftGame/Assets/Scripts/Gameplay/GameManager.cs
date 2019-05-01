﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject panel;
    public Text finishText;

    private Vector4 oldPanelColor;
    private JetStatus playerStatus;
    private AircraftMovement playerAircraft;
    private float timerLoadScene;
    private Image UIPanel;
    // Start is called before the first frame update
    private void Start()
    {
        oldPanelColor = new Vector4(0, 0, 0, 0.7f);
        playerStatus = JetStatus.Get();
        playerAircraft = player.GetComponent<AircraftMovement>();
        UIPanel = panel.GetComponent<Image>();
        finishText.text = "";
        UIPanel.color = new Vector4(0, 0, 0, 0);
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
        playerAircraft.enabled = false; //fpc.enabled = false;

        //UIPlayerHP.isGameFinished = true;
        finishText.text = "You Won!";
        finishText.color = Color.green;
        timerLoadScene += Time.deltaTime;
        UIPanel.color = oldPanelColor;

        if (timerLoadScene >= 3)
        {
            SceneManager.LoadScene("LevelTemplate");
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    private void playerLost()
    {
        playerAircraft.enabled = false; //fpc.enabled = false;

        //UIPlayerHP.isGameFinished = true;
        finishText.text = "You Lost!";
        finishText.color = Color.red;
        timerLoadScene += Time.deltaTime;
        UIPanel.color = oldPanelColor;

        if (timerLoadScene >= 3)
        {
            SceneManager.LoadScene("LevelTemplate");
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
