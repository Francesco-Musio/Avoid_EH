using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace StateMachine.GameSM
{
    public class GameSMLevelState : GameSMStateBase
    {

        public override void Enter()
        {
            context.outcome = Outcome.Unknown;
            context.timer = 0;

            SceneManager.LoadScene("GameScene");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene _scene, LoadSceneMode _mode)
        {
            LevelManager levelMng = FindObjectOfType<LevelManager>();
            levelMng.Init();
            levelMng.GameOver += OnGameOver;
            levelMng.Win += OnWin;
        }

        private void OnWin(float _timer)
        {
            context.outcome = Outcome.Win;
            context.timer = _timer;
            context.goToOutcomeCallback();
        }

        private void OnGameOver(float _timer)
        {
            context.outcome = Outcome.Lose;
            context.timer = _timer;
            context.goToOutcomeCallback();
        }

        public override void Exit()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
