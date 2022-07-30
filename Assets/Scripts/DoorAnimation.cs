using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    private bool _isOpened;
  // private Animator _animator;
  [SerializeField] private Animator _animator;
    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

public void Open()
    {
        _animator.SetBool("IsOpened", _isOpened);
        _isOpened = !_isOpened;
    }
}
