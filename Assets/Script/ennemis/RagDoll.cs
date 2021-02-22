using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider hitBox;

    // liste des elements du ragDoll
    private Collider[] listCollider;
    private Rigidbody[] listRb;

    private void Awake()
    {
        listCollider = GetComponentsInChildren<Collider>();
        listRb = GetComponentsInChildren<Rigidbody>();

        ActiverRagDoll(false);
    }

    public void ActiverRagDoll(bool _stat)
    {
        animator.enabled = !_stat;

        foreach(Collider col in listCollider)
        {
            col.enabled = _stat;
        }

        foreach(Rigidbody rb in listRb)
        {
            rb.isKinematic = !_stat;
        }

        hitBox.enabled = !_stat;
    }
}
