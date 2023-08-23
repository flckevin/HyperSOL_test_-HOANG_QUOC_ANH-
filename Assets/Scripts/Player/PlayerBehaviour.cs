using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    
    private int _health = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Ondamage() 
    {
        _health -= 1;
        AudioManager.Instance.PlayAudioOneshot(AudioManager.Instance.audioList["hitHurt_player"]);
        if (_health <= 0)
        {
            AudioManager.Instance.PlayAudioOneshot(AudioManager.Instance.audioList["explosion_player"]);
            GameManager.Instance.playerHealth[0].enabled = false;
            GameManager.Instance.gameOverMenu.SetActive(true);
            GameManager.Instance.gameUI.SetActive(false);
            GameManager.Instance.score_gameOverMenu.text = GameManager.Instance.highscore.score.ToString();
            Time.timeScale = 0;
        }
        else 
        {
            
            GameManager.Instance.playerHealth[_health].enabled = false;
        }
        

        
    }
}
