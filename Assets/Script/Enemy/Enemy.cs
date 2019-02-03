using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(EnemySightController))]
public class Enemy : MonoBehaviour
{
    #region Delegates
    public delegate void GameOverEvent();
    public GameOverEvent GameOver;
    #endregion

    private EnemySightController sightCtrl;

    #region API
    public void Init()
    {
        sightCtrl = GetComponent<EnemySightController>();
        if (sightCtrl != null)
            sightCtrl.Init(this);
    }
    #endregion
}
