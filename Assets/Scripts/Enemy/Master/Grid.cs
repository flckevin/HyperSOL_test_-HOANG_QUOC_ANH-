using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid 
{
    GameObject _origin;
    int _vertical, _horizontal, _row, _col;
    int enemyAmount;

    public Grid(GameObject _root) 
    {
        _origin = _root;

    }

    
    public void Initiate()
    {
        enemyAmount = PoolManager.Instance.enemies.Length;
        _vertical = (int)Mathf.Sqrt(enemyAmount);
        _horizontal = enemyAmount / _vertical;
        _col = _vertical;
        _row = _horizontal;

        for (int c = 0; c < _col; c++) 
        {
            for (int r = 0; r < _row; r++) 
            {
                SpawnTiles(r, c);
                
            }
        }

    }

    private void SpawnTiles(int x, int y) 
    {
        GameObject spawnedGrid = new GameObject($"grid :{x} , {y} ");
        spawnedGrid.transform.position = new Vector3(x - (_origin.transform.position.x + 1.5f), 
                                                        Mathf.Abs(y - (_origin.transform.position.y)));
        spawnedGrid.transform.SetParent(_origin.transform);
        GameManager.Instance.tiles.Add(spawnedGrid);
    
    }

}
