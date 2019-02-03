using UnityEngine;
using System.Collections;
using System;

namespace InputManagerNS
{
    public class InputManager : MonoBehaviour
    {
        #region Delegates
        public Action Horizontal;
        public Action Vertical;
        #endregion

        public static InputManager instance = null;
        private bool canMove = true;

        private CurrentInput currentInput;

        public void Init()
        {
            if (InputManager.instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }

            currentInput = new CurrentInput();
        }

        private void Update()
        {
            if (canMove)
            {
                if (Input.GetAxis("Horizontal") != 0)
                {
                    currentInput.horizontal = Input.GetAxis("Horizontal");
                    Horizontal();
                }

                if (Input.GetAxis("Vertical") != 0)
                {
                    currentInput.vertical = Input.GetAxis("Vertical");
                    Vertical();
                }
            }
        }

        #region Getters
        public CurrentInput GetCurrentInput()
        {
            return currentInput;
        }
        #endregion

        #region Setters
        public void SetCanMove(bool _newValue)
        {
            canMove = _newValue;
        } 
        #endregion
    }

    public class CurrentInput
    {
        internal float vertical = 0;
        internal float horizontal = 0;

        #region Getters
        public float GetVertical()
        {
            return vertical;
        }

        public float GetHorizontal()
        {
            return horizontal;
        }
        #endregion
    }
}


