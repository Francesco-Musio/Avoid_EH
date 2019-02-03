using UnityEngine;
using System.Collections;
using System;

public class EnemySightController : MonoBehaviour
{

    [Header("Sight options")]
    [SerializeField]
    [Range(5, 40)]
    private float angle;
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private SightRotation sightRotation;
    [SerializeField]
    private float rotationVelocity;

    private float deltaAngle = 0;

    private Enemy enemy;

    #region API
    public void Init(Enemy _enemy)
    {
        enemy = _enemy;
        StartCoroutine(AlertManager());
        StartCoroutine(Rotate());
    }
    #endregion

    #region Coroutines
    IEnumerator AlertManager()
    {
        bool _canCheck = true;
        while (_canCheck)
        {
            yield return new WaitForFixedUpdate();
            Collider2D _hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
            if (_hit != null)
            {
                Vector2 _directionToPlayer = (_hit.transform.position - transform.position).normalized;
                float _targetAngle = Vector2.Angle(transform.right, _directionToPlayer);

                if ((_targetAngle > 0 && _targetAngle < angle / 2))
                {
                    enemy.GameOver();
                    _canCheck = false;
                }

                if (_targetAngle >= (90 - angle / 2) && _targetAngle <= (90 + angle / 2))
                {
                    enemy.GameOver();
                    _canCheck = false;
                }

                if ((_targetAngle > 180 - angle / 2 && _targetAngle < 180))
                {
                    enemy.GameOver();
                    _canCheck = false;
                }
            }
        }
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            switch (sightRotation)
            {
                case SightRotation.Right:
                    transform.RotateAround(transform.position, Vector3.forward, -rotationVelocity * Time.deltaTime);
                    break;
                case SightRotation.Left:
                    transform.RotateAround(transform.position, Vector3.forward, rotationVelocity * Time.deltaTime);
                    break;
            }
        }
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

public enum SightRotation
{
    Right,
    Left
}
