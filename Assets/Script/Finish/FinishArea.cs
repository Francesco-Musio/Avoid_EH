using UnityEngine;
using System.Collections;

public class FinishArea : MonoBehaviour
{
    #region Delegates
    public delegate void FinishEvent();
    public FinishEvent Finish;
    #endregion

    private bool canTrigger = true;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTrigger && collision.gameObject.layer == 8)
        {
            canTrigger = false;
            Finish();
        }
    }

}
