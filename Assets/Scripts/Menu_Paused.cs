using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Paused : MonoBehaviour
{
    public GameObject menuPaused;
    [SerializeField] KeyCode keyMenuPaused;
    bool isMenuPaused = false;
    private void Start()
    {
        menuPaused.SetActive(false);
    }
    private void Update()
    {
        ActiveMenu();
    }
    void ActiveMenu()
    {
        if (Input.GetKeyDown(keyMenuPaused))
        {
            isMenuPaused = !isMenuPaused;
        }

        if (isMenuPaused)
        {
            menuPaused.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            menuPaused.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void MenuContinue()
    {
        isMenuPaused = false;
    }
    public void MenuExit()
    {
        SceneManager.LoadScene(0);
    }
    public void MenuOptions()
    {
        SceneManager.LoadScene(2);
    }

}
