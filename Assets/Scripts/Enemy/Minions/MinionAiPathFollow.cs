using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Data;

public class MinionAiPathFollow 
{
    private bool added = false;
    private Transform _nextPath;
    private int _currentPath = 0;
    private MinionBehaviour _currentMinion;
    private GameObject _patternStorage;
    private List<Transform> _paths = new List<Transform>();
    private Action _actionAftergoalReach;
    
    public MinionAiPathFollow (MinionBehaviour _minion, GameObject _pattern) 
    {
        this._currentMinion = _minion;
        this._patternStorage = _pattern;
      
    }

    

    public IEnumerator Move() 
    {
        #region Path setup

        int childInPattern = _patternStorage.transform.childCount;
        for (int i = 0; i < childInPattern; i++) 
        {
            _paths.Add(_patternStorage.transform.GetChild(i));
        }

        #endregion

        #region Move Minon

        _nextPath = _paths[_currentPath];
        
        while (_currentPath != _paths.Count - 1)
        {
            //vector 2 will reset z axis value back to 0 so that we use vector 3
            Vector3 _nextTarget = new Vector3(_nextPath.transform.position.x, _nextPath.transform.position.y, _currentMinion.transform.position.z);
           
            _currentMinion.transform.position = Vector3.MoveTowards(_currentMinion.transform.position,
                                                                    _nextTarget,
                                                                    3 * Time.deltaTime);
            
            //Debug.Log(Vector2.Distance(_currentMinion.transform.position, _nextPath.localPosition));

            if (Vector2.Distance(_currentMinion.transform.position, _nextPath.position) <= 0 && _currentPath != _paths.Count - 1)
            {
                _currentPath++;
                _nextPath = _paths[_currentPath];

                //BUG here 02:07 AM 23/08/2023
                //because while loop couroutine act like fixed update we are adding the amout of minion double the real minion amount
                //we need to have a bool to stop execute code in condition block
                if (_currentPath == _paths.Count - 1) 
                {
                    if(added == false) 
                    {
                        GameManager.Instance.master.currentMinionAmount += 1;
                        GameManager.Instance.master.CheckMinion();
                        
                        added = true;
                    }
                    
                    //Debug.Log("stopped" + _currentMinion.name);
                }
               
            }

            yield return null;
          
        }

        

        #endregion
    }
}
