using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class MinionAiPathFollow 
{
    private Transform _nextPath;
    private int _currentPath = 0;
    private MinionBehaviour _currentMinion;
    private GameObject _patternStorage;
    private List<Transform> _paths = new List<Transform>();
    public Action actionAftergoalReach;

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
        while (_currentPath != _paths.Count)
        {
            //vector 2 will reset z axis value back to 0 so that we use vector 3
            Vector3 _nextTarget = new Vector3(_nextPath.transform.position.x, _nextPath.transform.position.y, _currentMinion.transform.position.z);
           
            _currentMinion.transform.position = Vector3.MoveTowards(_currentMinion.transform.position,
                                                                    _nextTarget,
                                                                    1 * Time.deltaTime);

            //Debug.Log(Vector2.Distance(_currentMinion.transform.position, _nextPath.localPosition));

            if (Vector2.Distance(_currentMinion.transform.position, _nextPath.position) <= 1 && _currentPath != _paths.Count - 1)
            {
                _currentPath++;
                _nextPath = _paths[_currentPath];
                
            }



            yield return null;
        }

        if (actionAftergoalReach != null)
        {
            actionAftergoalReach();
            _paths.Clear();
            
        }
        #endregion
    }
}
