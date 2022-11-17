using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
public class MenuStart : MonoBehaviour {


    public void PlayGame()
    {
        SceneManager.LoadScene("Phase 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}