using UnityEngine;

public class Door : MonoBehaviour
{
    private AudioSource _audioSource;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Open()
    {
        _animator.Play("Open");
        _audioSource.Play();
    }
}