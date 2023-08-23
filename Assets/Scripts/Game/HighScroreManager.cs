using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScroreManager : MonoBehaviour
{
    public int _score;
    public TextMeshProUGUI textMesh;
    private int _highestScore;
    private void Start()
    {
        _highestScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    public void UpdateScore() 
    {
        _score++;
        textMesh.text = _score.ToString();
        if (_score > _highestScore) 
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
    }
}
