using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("PLAYER INFO")]
    public PlayerBehaviour player;

    [Space(10)]
    [Header("ENEMY INFO")]
    public MinionBehaviour[] minons;

    [Space(10)]
    [Header("ENEMY FORMATION PATTERNS")]
    public List<GameObject> patterns;

   
}
