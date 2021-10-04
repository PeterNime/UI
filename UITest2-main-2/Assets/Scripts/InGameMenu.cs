using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InGameMenu : MonoBehaviour {

    public GameObject inGamePanel;
    public GameObject HUDPanel;
    public bool gamePaused;
    public PlayerMovement playerMov;
    public TextMeshProUGUI playerJump;

    void Start() {
        gamePaused = false;
        inGamePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void Update() {
        playerJump.text = playerMov.jumpNumber.ToString();

        if (Input.GetKeyDown(KeyCode.Escape)) {
            HUDPanel.SetActive(false);
            gamePaused = true;
            inGamePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void UnPause() {
        HUDPanel.SetActive(true);
        gamePaused = false;
        inGamePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void MainMenuLevel() {
        SceneManager.LoadScene(0);
    }
}
