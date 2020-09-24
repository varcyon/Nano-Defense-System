using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    private void Start() {
        
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToUnits()
    {
        SceneManager.LoadScene("Units");
    }
 public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void resumeGame(){
        GameManager.i.pause();
    }

    public void Replay(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());
       // GameManager.i.pause();
    }
}
