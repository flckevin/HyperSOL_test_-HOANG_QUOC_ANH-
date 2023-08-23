using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentMinionAmount = 0;
    public float sortingSpeed;
    private int _sortedMinion;
    void Start()
    {
        Grid grid = new Grid(this.gameObject);
        grid.Initiate();
        CheckMinion();
    }


    #region Master Behaviour

    #endregion


    #region Minion Manager

    public void CheckMinion() 
    {
        if (currentMinionAmount == 0)
        {
            _sortedMinion = 0;
            StartCoroutine(DelaySpawn());
        }
        else if (currentMinionAmount >= (PoolManager.Instance.enemies.Length)*2) 
        {
            
            SortMinion();
        }
    }

    IEnumerator DelaySpawn() 
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < PoolManager.Instance.enemies.Length; i++)
        {
            PoolManager.Instance.enemies[i].gameObject.SetActive(true);
            PoolManager.Instance.enemies[i].GetInFormation();
            
            
        }

    }


    public void SortMinion() 
    {
        Debug.Log("CALLED");
        StartCoroutine(SortMinions());
    }

    IEnumerator SortMinions() 
    {
        
        
        while(_sortedMinion != PoolManager.Instance.enemies.Length) 
        {
            
            if (Vector3.Distance(PoolManager.Instance.enemies[_sortedMinion].transform.localPosition,
                GameManager.Instance.tiles[_sortedMinion].transform.position) != 0 )
            {
                Vector3 _nextTarget = new Vector3(GameManager.Instance.tiles[_sortedMinion].transform.position.x,
                                                    GameManager.Instance.tiles[_sortedMinion].transform.position.y,
                                                    PoolManager.Instance.enemies[_sortedMinion].transform.position.z);

                PoolManager.Instance.enemies[_sortedMinion].transform.position = Vector3.MoveTowards(PoolManager.Instance.enemies[_sortedMinion].transform.position,
                                                                                                    _nextTarget, sortingSpeed * Time.deltaTime);

               
            }
            else 
            {
                _sortedMinion++;
                
            }

            yield return null;
        }
    
    }
    #endregion
}
