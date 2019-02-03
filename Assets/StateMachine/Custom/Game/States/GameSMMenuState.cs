using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace StateMachine.GameSM
{
    public class GameSMMenuState : GameSMStateBase
    {
        private MainMenuCanvas mmMng;

        public override void Enter()
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MenuScene"))
            {
                SceneManager.LoadScene("MenuScene");
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            else
            {
                mmMng = FindObjectOfType<MainMenuCanvas>();
                mmMng.GoToLevel += OnStartPressed;
            }
        }

        private void OnSceneLoaded(Scene _scene, LoadSceneMode _mode)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            mmMng = FindObjectOfType<MainMenuCanvas>();
            mmMng.GoToLevel += OnStartPressed;
        }

        private void OnStartPressed()
        {
            context.goToLevelCallback();
        }

        public override void Exit()
        {
            mmMng.GoToLevel -= OnStartPressed;
        }
    }
}
