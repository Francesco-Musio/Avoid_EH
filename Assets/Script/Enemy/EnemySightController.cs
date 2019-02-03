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

    private Enemy enemy;

    private bool _canCheck = false;

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
        _canCheck = true;
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
                    StopCoroutine(Rotate());
                }

                if (_targetAngle >= (90 - angle / 2) && _targetAngle <= (90 + angle / 2))
                {
                    enemy.GameOver();
                    _canCheck = false;
                    StopCoroutine(Rotate());
                }

                if ((_targetAngle > 180 - angle / 2 && _targetAngle < 180))
                {
                    enemy.GameOver();
                    _canCheck = false;
                    StopCoroutine(Rotate());
                }
            }
        }
    }

    IEnumerator Rotate()
    {
        while (_canCheck)
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

        // Raggi a destra
        Quaternion leftRayRotation = Quaternion.AngleAxis(-angle/2, Vector3.forward);
        Quaternion rightRayRotation = Quaternion.AngleAxis(angle/2, Vector3.forward);
        Vector3 leftRayDirection = leftRayRotation * transform.right;
        Vector3 rightRayDirection = rightRayRotation * transform.right;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, leftRayDirection * radius);
        Gizmos.DrawRay(transform.position, rightRayDirection * radius);

        // Raggi a sinistra
        leftRayRotation = Quaternion.AngleAxis(180 - angle / 2, Vector3.forward);
        rightRayRotation = Quaternion.AngleAxis(180 + angle / 2, Vector3.forward);
        leftRayDirection = leftRayRotation * transform.right;
        rightRayDirection = rightRayRotation * transform.right;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, leftRayDirection * radius);
        Gizmos.DrawRay(transform.position, rightRayDirection * radius);

        // Raagi sopra
        leftRayRotation = Quaternion.AngleAxis(90 - angle / 2, Vector3.forward);
        rightRayRotation = Quaternion.AngleAxis(90 + angle / 2, Vector3.forward);
        leftRayDirection = leftRayRotation * transform.right;
        rightRayDirection = rightRayRotation * transform.right;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, leftRayDirection * radius);
        Gizmos.DrawRay(transform.position, rightRayDirection * radius);

        // Raggi sotto
        leftRayRotation = Quaternion.AngleAxis(270 - angle / 2, Vector3.forward);
        rightRayRotation = Quaternion.AngleAxis(270 + angle / 2, Vector3.forward);
        leftRayDirection = leftRayRotation * transform.right;
        rightRayDirection = rightRayRotation * transform.right;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, leftRayDirection * radius);
        Gizmos.DrawRay(transform.position, rightRayDirection * radius);
    }
}

public enum SightRotation
{
    Right,
    Left
}
