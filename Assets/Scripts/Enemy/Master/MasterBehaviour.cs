using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentMinionAmount = 0;
    public float sortingSpeed;
    public float movingSpeed;

    public int _sortedMinion;
    private List<Transform> _paths = new List<Transform>();
    private int _masterPathTravelled;
    private Vector3 _originPosition;
    bool reversed = false;
    void Start()
    {

        for (int i = 0; i < PoolManager.Instance.enemies.Length; i++) 
        {
            PoolManager.Instance.enemies[i].transform.parent = GameManager.Instance.enemiesCarrier;
        }

        _originPosition = this.transform.position;
        Grid grid = new Grid(this.gameObject);
        grid.Initiate();
        CheckMinion();
    }


    #region Master Behaviour
    void MasterPathSetup() 
    {
        Transform pattern = GameManager.Instance.masterPathsPatterns[0];
        int childInPathPatterns = pattern.childCount;

        for (int i = 0; i < childInPathPatterns; i++) 
        {
            _paths.Add(pattern.GetChild(i));
        }

        if (_paths.Count == 0) return;

        #region Minion Finalize

        for (int i = 0; i < PoolManager.Instance.enemies.Length; i++) 
        {
            PoolManager.Instance.enemies[i].GetComponent<BoxCollider2D>().enabled = true;
        }

        #endregion

        StartCoroutine(MasterFollowPath());

            
    }

    IEnumerator MasterFollowPath() 
    {
        
        while (currentMinionAmount > 0) 
        {
            #region getTarget
            //vector 2 will reset z axis value back to 0 so that we use vector 3
            Vector3 _nextTarget = new Vector3(_paths[_masterPathTravelled].transform.position.x,
                                            _paths[_masterPathTravelled].transform.position.y, 
                                            this.transform.position.z);
            #endregion

            #region move to target
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                                                                    _nextTarget,
                                                                    movingSpeed * Time.deltaTime);
            #endregion

            #region Condition checking

                if (reversed == false 
                    && Vector3.Distance(this.transform.position, _nextTarget) <= 0
                    )
                {

                    if (_masterPathTravelled >= _paths.Count - 1 && Vector3.Distance(this.transform.position, _nextTarget) <= 0)
                    {
                        reversed = true;
                        _masterPathTravelled--;
                        _nextTarget = new Vector3(_paths[_masterPathTravelled].transform.position.x,
                                            _paths[_masterPathTravelled].transform.position.y,
                                            this.transform.position.z);
                    }
                    else 
                    {
                        _masterPathTravelled++;
                    }

                   // Debug.Log(_nextTarget + "|" + reversed + "|" + _masterPathTravelled);

                }
                else if(reversed == true 
                        && Vector3.Distance(this.transform.position, _nextTarget) <= 0
                        )
                {
                    
                    if (_masterPathTravelled == 0 && Vector3.Distance(this.transform.position, _nextTarget) <= 0)
                    {
                        reversed = false;
                        _masterPathTravelled++;
                        _nextTarget = new Vector3(_paths[_masterPathTravelled].transform.position.x,
                                            _paths[_masterPathTravelled].transform.position.y,
                                            this.transform.position.z);
                    }
                    else 
                    {
                        _masterPathTravelled--;
                    }
                }
            
            #endregion


            //Debug.Log(_masterPathTravelled + "|" + _paths.Count);
            yield return null;

        }
    
    }

    #endregion


    #region Minion Manager

    public void CheckMinion() 
    {
        if (currentMinionAmount == 0)
        {
            this.transform.position = _originPosition;
            
            StartCoroutine(DelaySpawn_Minion());
        }
        else if (currentMinionAmount >= PoolManager.Instance.enemies.Length) 
        {
            _masterPathTravelled = 0;
            _sortedMinion = 0;
            currentMinionAmount = PoolManager.Instance.enemies.Length;
            SortMinion();
        }
    }

    IEnumerator DelaySpawn_Minion() 
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
       // Debug.Log("CALLED");
        StartCoroutine(SortMinions());
    }

    IEnumerator SortMinions() 
    {
        
        
        while(_sortedMinion != PoolManager.Instance.enemies.Length) 
        {
            //we need to compare the root of gameobject itself so that we use position istead of localposition
            if (Vector2.Distance(PoolManager.Instance.enemies[_sortedMinion].transform.position,
                GameManager.Instance.tiles[_sortedMinion].transform.position) != 0)
            {
                //Debug.Log(Vector2.Distance(PoolManager.Instance.enemies[_sortedMinion].transform.position,
                //GameManager.Instance.tiles[_sortedMinion].transform.position));

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

        MasterPathSetup();
    }
    #endregion
}
