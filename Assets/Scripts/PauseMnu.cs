using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMnu : MonoBehaviour
{
    public GameObject pauseScrn;
    public bool pauseScrnOn = false;
    public AudioSource rain;
    public GameObject optionScrn;
    public bool optionScrnOn = false;
    public GameObject gameOver;

    private void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseScrnOn == false && gameOver.GetComponent<KillState>().isdead == false)
        {
            Time.timeScale = 0;
            pauseScrn.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            rain.Pause();
            pauseScrnOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseScrnOn == true)
        {
            Time.timeScale = 1;
            pauseScrn.SetActive(false);
            optionScrn.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            rain.Play();
            pauseScrnOn = false;
        }
    }

    public void OpenMenu() 
    {
        if (Input.GetKey(KeyCode.Escape) && gameOver.GetComponent<KillState>().isdead == false)
        {
            Time.timeScale = 0;
            pauseScrn.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            rain.Pause();
        }
    }

    public void CloseMenu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 1;
            pauseScrn.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            rain.Play();
        }
    }

    public void backButton()
    {
        Time.timeScale = 1;
        pauseScrn.SetActive(false);
        rain.Play();
        Cursor.lockState = CursorLockMode.Locked;
        pauseScrnOn = false;

    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Options()
    {
        pauseScrn.SetActive(false);
        optionScrn.SetActive(true);
        pauseScrnOn = true;
    }

    public void OptionsBack()
    {
        optionScrn.SetActive(false);
        pauseScrn.SetActive(true);
    }
}
