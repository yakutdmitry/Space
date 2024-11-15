using System;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _animator.SetTrigger("Open");
    }

    private void OnTriggerExit(Collider other)
    {
        _animator.SetTrigger("Close");
    }
}
