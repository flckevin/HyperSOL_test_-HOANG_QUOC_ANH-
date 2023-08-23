using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Text highestScore;

    void Start()
    {
        highestScore.text = $"HIGH SCORE: {PlayerPrefs.GetInt("HighScore").ToString()}";
    }

    public void LoadScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
    
}
