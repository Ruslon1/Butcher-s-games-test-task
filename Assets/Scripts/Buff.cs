using UnityEngine;

public class Buff : MonoBehaviour
{
    [SerializeField] private int _expImpact;

    public int ExpImpact => _expImpact;
}