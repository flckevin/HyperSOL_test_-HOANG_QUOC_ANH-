using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [Header("BULLETS")]
    public BulletBehaviour[] bullets;
    private int _bulletID = 0;
    public int BulletID 
    {
        get { return _bulletID; }
        set 
        {
            if (_bulletID >= bullets.Length - 1)
            {
                _bulletID = 0;
            }
            else 
            {
                _bulletID = value;
            }
        
        }
    }
    [Space(10)]

    [Header("ENEMIES")]
    public MinionBehaviour[] enemies;
    

}
