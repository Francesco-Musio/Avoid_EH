using UnityEngine;
using System.Collections;
using InputManagerNS;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Movement Options")]
    [SerializeField]
    private float movementVelocity;

    private CurrentInput currentInput;

    private void LimitBounds()
    {
        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.025f, 0.975f);
        pos.y = Mathf.Clamp(pos.y, 0.025f, 0.975f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    #region API
    public void Init(InputManager _input)
    {
        if (_input.Horizontal == null)
            _input.Horizontal += HandleHorizontalMovement;
        if (_input.Vertical == null)
            _input.Vertical += HandleVerticalMovement;

        currentInput = _input.GetCurrentInput();
    }
    #endregion

    #region Handlers
    private void HandleVerticalMovement()
    {
        transform.Translate(new Vector3(0, currentInput.vertical * movementVelocity * Time.deltaTime, 0));
        LimitBounds();
    }

    private void HandleHorizontalMovement()
    {
        transform.Translate(new Vector3(currentInput.horizontal * movementVelocity * Time.deltaTime, 0, 0));
        LimitBounds();
    }
    #endregion
}
