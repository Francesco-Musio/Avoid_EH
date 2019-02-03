using UnityEngine;
using System.Collections;
using System;

namespace StateMachine.GameSM
{
    public class GameSMController : StateMachineBase
    {

        private Animator gameSM;
        private GameSMContext context;
        private GameManager gameMng;

        #region API
        public void Init(GameManager _gm)
        {
            gameSM = GetComponent<Animator>();
            gameMng = _gm;

            context = new GameSMContext(gameMng, HandleGoToLevelCallback, HandleGoToOutcomeCallback, HandleGoToMenuCallback);

            foreach (StateMachineBehaviour state in gameSM.GetBehaviours<StateMachineBehaviour>())
            {
                IState newstate = state as IState;
                if (newstate != null)
                    newstate.Setup(context);
            }

            gameSM.SetTrigger("StartSM");
        }
        #endregion

        #region Handlers
        public void HandleGoToLevelCallback()
        {
            gameSM.SetTrigger("GoToLevel");
        }

        public void HandleGoToOutcomeCallback()
        {
            gameSM.SetTrigger("GoToOutcome");
        }

        public void HandleGoToMenuCallback()
        {
            gameSM.SetTrigger("GoToMenu");
        }
        #endregion
    }

    public class GameSMContext : IStateMachineContext
    {
        public GameManager gameMng;
        public Outcome outcome = Outcome.Unknown;
        public float timer;

        public Action goToMenucallback;
        public Action goToLevelCallback;
        public Action goToOutcomeCallback;

        public GameSMContext(GameManager _gm, Action _goToLevelCallback, Action _goToOutcomeCallback, Action _goToMenucallback)
        {
            gameMng = _gm;
            goToLevelCallback = _goToLevelCallback;
            goToOutcomeCallback = _goToOutcomeCallback;
            goToMenucallback = _goToMenucallback;
        }
    }

    public enum Outcome
    {
        Unknown,
        Win,
        Lose
    }
}
