using UnityEngine;
using System.Collections;

public class MainMenuCanvas : MonoBehaviour
{
    #region Delegates
    public delegate void GoToLevelEvent();
    public GoToLevelEvent GoToLevel;
    #endregion

    public void StartButton()
    {
        GoToLevel();
    }
}
