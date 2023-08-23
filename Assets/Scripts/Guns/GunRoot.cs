using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRoot : MonoBehaviour
{
    public GunStats_Scriptable gunStats;

    protected AudioSource _audioSrc;
    protected float _lastTimeShoot;
    // Start is called before the first frame update
    void Start()
    {
        _audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //fire rate
        if (Time.time > _lastTimeShoot + gunStats.fireRate) 
        {
            _lastTimeShoot = Time.time;
            GunBehaviour();
        }
        
    }

    public virtual void GunBehaviour() { }

}
