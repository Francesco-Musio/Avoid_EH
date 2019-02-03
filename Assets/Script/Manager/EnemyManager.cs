using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemyManager : MonoBehaviour
{
    #region Delegates
    public delegate void GameOverEvent();
    public GameOverEvent GameOver;
    #endregion

    [Header("Settings")]
    [SerializeField]
    private Transform enemyContainer;

    private List<Enemy> activeEnemies = new List<Enemy>();

    #region API
    public void Init()
    {
        for (int i = 0; i < enemyContainer.childCount; i++)
        {
            Enemy _current = enemyContainer.GetChild(i).GetComponent<Enemy>();
            activeEnemies.Add(_current);
            _current.Init();
            _current.GameOver += HandleGameOver;
        }
    }
    #endregion

    #region Handlers
    private void HandleGameOver()
    {
        GameOver();
    }
    #endregion

}
