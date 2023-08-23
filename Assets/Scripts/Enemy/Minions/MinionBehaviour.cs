using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MinionBehaviour : MonoBehaviour
{
    public MinionStats minionStats;

    private Rigidbody2D _minionRigi;
    private float _health;
    private Vector3 _originPos;
    // Start is called before the first frame update

    void Start()
    {
        //*get*
        _minionRigi = this.gameObject.GetComponent<Rigidbody2D>();

        //*set*
        _health = minionStats.health;
        //we set z axis to 0 since the minion itself will child to an object has z axis with -10 value
        //so if we adjust z axis of the minion itslef, it will go out of camera
        _originPos = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        //_minionRigi.simulated = false;

        
    }

    public void GetInFormation() 
    {
      
        MinionAiPathFollow minion = new MinionAiPathFollow(this, GameManager.Instance.patterns[0]);
        StartCoroutine(minion.Move());
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {
            OnDamage(int.Parse(collision.name));
        }
    }

    private void OnDamage(float _damageValue) 
    {
        //Debug.Log("Damaged");
        _health-=_damageValue;
        if (_health > 0) return;
        this.gameObject.SetActive(false);
        GameManager.Instance.master.currentMinionAmount--;
        GameManager.Instance.master.CheckMinion();
        GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.transform.localPosition = _originPos;
    }
}
