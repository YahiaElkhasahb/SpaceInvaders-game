using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pausemenu ;
    public static bool Ispaused =false ;
    // Start is called before the first frame update
    void Start()
    {
        Pausemenu.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Ispaused)
            {
                Resumegame();
            }
            else
            {
                PauseGame() ;
            }
        }
        
    }
    public void PauseGame()
    {   
        Pausemenu.SetActive(true);
        Time.timeScale = 0f;
        Ispaused = true;
    }
    public void Resumegame()
    {
        Pausemenu.SetActive(false);
        Time.timeScale = 1f;
        Ispaused = false;
    }
    public void Mainmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();

    }
}
