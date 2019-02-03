using UnityEngine;
using System.Collections;
using InputManagerNS;
using System;

[RequireComponent(typeof(InputManager))]
public class LevelManager : MonoBehaviour
{
    #region Delegates
    public Action GameOver;
    #endregion

    private Player player;
    private InputManager inputMng;
    private EnemyManager enemyMng;

    [Header("Level Settings")]
    [SerializeField]
    private Transform startingPoint;
    [SerializeField]
    private FinishArea finishArea;

    private bool canCount = false;
    private float timer = 0;

    //Replace con Init da GameManager
    private void Start()
    {
        inputMng = GetComponent<InputManager>();
        if (inputMng != null)
            inputMng.Init();
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player != null)
            player.Init(startingPoint);

        enemyMng = GetComponent<EnemyManager>();
        if (enemyMng != null)
            enemyMng.Init();

        //passare evento per fine gioco
        finishArea.Finish += HandleFinish;

        enemyMng.GameOver += HandleGameOver;

        canCount = true;
    }

    private void Update()
    {
        if (canCount)
        {
            timer += Time.deltaTime;
        }
    }

    #region Handlers
    private void HandleGameOver()
    {
        Debug.Log("GameOver");
        inputMng.SetCanMove(false);
        canCount = false;
        Debug.Log(timer);
    }

    private void HandleFinish()
    {
        Debug.Log("Finish");
        canCount = false;
        Debug.Log(timer);
    }
    #endregion
    
}
