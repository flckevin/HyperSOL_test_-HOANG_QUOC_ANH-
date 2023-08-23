using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
