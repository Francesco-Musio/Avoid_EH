using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementController))]
public class Player : MonoBehaviour
{
    private PlayerMovementController movementCtrl;

    #region API
    public void Init(Transform _startingPoint)
    {
        movementCtrl = GetComponent<PlayerMovementController>();
        if (movementCtrl != null)
            movementCtrl.Init();

        transform.position = _startingPoint.position;
    }
    #endregion

}
