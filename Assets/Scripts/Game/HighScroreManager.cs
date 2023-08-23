using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScroreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI textMesh;
    private int _highestScore;
    private void Start()
    {
        _highestScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    public void UpdateScore() 
    {
        score++;
        textMesh.text = score.ToString();
        if (score > _highestScore) 
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
