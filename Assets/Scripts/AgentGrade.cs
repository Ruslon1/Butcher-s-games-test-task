using System;
using Unity.VisualScripting;
using UnityEngine;

public class AgentGrade : MonoBehaviour
{
    public const int ExpToNextGrade = 10;

    [SerializeField] private GameObject[] _appearances;
    [SerializeField] private AudioClip _addSound;
    [SerializeField] private AudioClip _removeSound;

    private AudioSource _audioSource;
    private int _currentExp;
    private int _previousExp;
    private Agent _agent;

    public int CurrentExp
    {
        get { return _currentExp; }
        set { _currentExp = Mathf.Clamp(value, 0, _appearances.Length * ExpToNextGrade); }
    }

    public int PreviousExp
    {
        get { return _previousExp; }
        set { _previousExp = Mathf.Clamp(value, 0, _appearances.Length * ExpToNextGrade); }
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _agent = GetComponent<Agent>();
        _appearances[0].gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Buff buff))
        {
            PreviousExp = CurrentExp;
            CurrentExp += buff.ExpImpact;

            if (PreviousExp / ExpToNextGrade != CurrentExp / ExpToNextGrade)
            {
                ChangeGrade();
            }

            buff.gameObject.SetActive(false);

            if (buff.ExpImpact > 0)
            {
                _audioSource.clip = _addSound;
                _audioSource.Play();
            }
            else
            {
                _audioSource.clip = _removeSound;
                _audioSource.Play();
            }
        }

        if (other.TryGetComponent(out Door door))
        {
            PreviousExp = CurrentExp;
            CurrentExp -= ExpToNextGrade;

            if (CurrentExp >= ExpToNextGrade)
            {
                door.Open();
            }
            else
            {
                _agent.Context.Gameplay.FinishGameplay();
            }
        }
    }

    private void ChangeGrade()
    {
        if (CurrentExp / ExpToNextGrade > _appearances.Length == false)
        {
            _appearances[PreviousExp / ExpToNextGrade].gameObject.SetActive(false);
            _appearances[CurrentExp / ExpToNextGrade].gameObject.SetActive(true);
        }
    }
}