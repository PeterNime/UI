using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject optionsMenu;
    public GameObject quitMenu;

    void Start()
    {
        optionsMenu.SetActive(false);
        quitMenu.SetActive(false);
    }

    public void ShowOptionsMenu() {
        startMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ShowMainMenu() {
        startMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void OpenLevel() {
        SceneManager.LoadScene(1);
    }

    public void Close() {
        Application.Quit();
        Debug.Log("Quitting application");
    }
}
