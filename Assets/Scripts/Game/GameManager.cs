using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : Singleton<GameManager>
{
    [Header("PLAYER INFO")]
    public PlayerBehaviour player;

    [Space(10)]
    [Header("ENEMY INFO")]
    public MasterBehaviour master;
    public List<Transform> masterPathsPatterns;
    public Transform enemiesCarrier;

    [Space(10)]
    [Header("ENEMY FORMATION PATTERNS")]
    public List<GameObject> patterns;

    [Space(10)]

    [Header("TILES")]
    public List<GameObject> tiles = new List<GameObject>();

    [Space(10)]
    [Header("HIGH SCORE")]
    public HighScroreManager highscore;

    [Space(10)]
    [Header("UI")]
    public Image[] playerHealth;
    public GameObject gameOverMenu;
    public GameObject gameUI;
    public TextMeshProUGUI score_gameOverMenu;
}
