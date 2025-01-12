using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void Play(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void Quit(){
        Application.Quit();
    }
}
