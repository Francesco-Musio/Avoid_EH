using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using StateMachine.GameSM;
using System;

public class OutcomeCanvas : MonoBehaviour
{
    #region Delegates
    public Action Replay;
    public Action Menu;
    #endregion

    [SerializeField]
    private Text outcomeText;
    [SerializeField]
    private Text timerText;

    #region API
    public void Init(Outcome _outcome, float _timer)
    {
        switch (_outcome)
        {
            case Outcome.Win:
                outcomeText.text = "You Win!";
                break;
            case Outcome.Lose:
                outcomeText.text = "You Lose";
                break;
        }

        timerText.text = "Your run lasted " + string.Format("{0:0.00}", _timer) + " seconds";
    }
    #endregion

    #region OnClicks
    public void OnReplay()
    {
        Replay();
    }

    public void OnMenu()
    {
        Menu();
    }
    #endregion
}
