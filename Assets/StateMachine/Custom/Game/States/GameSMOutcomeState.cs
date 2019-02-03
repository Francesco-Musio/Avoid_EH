using UnityEngine;
using System.Collections;

namespace StateMachine.GameSM
{
    public class GameSMOutcomeState : GameSMStateBase
    {
        public override void Enter()
        {
            LevelManager levelMng = FindObjectOfType<LevelManager>();
            OutcomeCanvas outcomeCnv = levelMng.GetOutcomeCanvas();
            outcomeCnv.gameObject.SetActive(true);
            outcomeCnv.Init(context.outcome, context.timer);
            outcomeCnv.Replay += OnReplay;
            outcomeCnv.Menu += OnMenu;
        }

        private void OnReplay()
        {
            context.goToLevelCallback();
        }

        private void OnMenu()
        {
            context.goToMenucallback();
        }
    }
}
