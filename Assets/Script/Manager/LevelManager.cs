using UnityEngine;
using System.Collections;
using InputManagerNS;
using System;

[RequireComponent(typeof(InputManager))]
public class LevelManager : MonoBehaviour
{
    #region Delegates
    public delegate void FinishEvent(float _timer);
    public FinishEvent GameOver;
    public FinishEvent Win;
    #endregion

    private Player player;
    private InputManager inputMng;
    private EnemyManager enemyMng;

    [SerializeField]
    private OutcomeCanvas outcomeCnv;

    [Header("Level Settings")]
    [SerializeField]
    private Transform startingPoint;
    [SerializeField]
    private FinishArea finishArea;

    private bool canCount = false;
    private float timer = 0;

    #region API
    public void Init()
    {
        inputMng = GetComponent<InputManager>();
        if (inputMng != null)
            inputMng.Init();
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player != null)
            player.Init(startingPoint, inputMng);

        enemyMng = GetComponent<EnemyManager>();
        if (enemyMng != null)
            enemyMng.Init();
        
        finishArea.Finish += HandleFinish;

        enemyMng.GameOver += HandleGameOver;

        canCount = true;
    }
    #endregion

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
        inputMng.SetCanMove(false);
        canCount = false;
        GameOver(timer);
    }

    private void HandleFinish()
    {
        canCount = false;
        Win(timer);
    }
    #endregion

    #region Getters
    public OutcomeCanvas GetOutcomeCanvas()
    {
        return outcomeCnv;
    }
    #endregion

}
