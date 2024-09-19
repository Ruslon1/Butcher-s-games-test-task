using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class Agent : ContextBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _characterController;
    private Animator _animator;

    private bool _canMove = true;
    private static readonly int CanWalk = Animator.StringToHash("CanWalk");

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Context.ObservedAgent = this;
        Context.SceneCamera.AttachToAgent();
    }

    private void Update()
    {
        if (_canMove == false)
            return;

        _characterController.Move(transform.right * Mouse.current.delta.value.x * 3 * Time.deltaTime +
                                  transform.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RotatePoint rotatePoint))
        {
            transform.DORotate(new Vector3(0, rotatePoint.RotateAngle, 0), 1, RotateMode.FastBeyond360);
        }
    }

    public void Finish()
    {
        _canMove = false;
        _animator.SetBool(CanWalk, false);
    }
}