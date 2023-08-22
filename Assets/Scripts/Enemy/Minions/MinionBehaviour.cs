using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBehaviour : MonoBehaviour
{
    public MinionStats minionStats;
    private float _health;
    // Start is called before the first frame update
    void Start()
    {
        //*get*


        //*set*
        _health = minionStats.health;

        //*Start behaviour*
        MinionAiPathFollow minion = new MinionAiPathFollow(this, GameManager.Instance.patterns[0]);
        StartCoroutine(minion.Move());
    }

    
}
