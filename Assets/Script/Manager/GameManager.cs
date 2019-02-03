using UnityEngine;
using System.Collections;
using System;
using StateMachine.GameSM;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private GameSMController gameSMController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        gameSMController = GetComponent<GameSMController>();
        if (gameSMController != null)
            gameSMController.Init(this);
    }
}
