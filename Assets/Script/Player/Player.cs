using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputManagerNS;

[RequireComponent(typeof(PlayerMovementController))]
public class Player : MonoBehaviour
{
    private PlayerMovementController movementCtrl;

    #region API
    public void Init(Transform _startingPoint, InputManager _input)
    {
        movementCtrl = GetComponent<PlayerMovementController>();
        if (movementCtrl != null)
            movementCtrl.Init(_input);

        transform.position = _startingPoint.position;
    }
    #endregion

}
