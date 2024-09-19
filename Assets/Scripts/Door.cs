using UnityEngine;

public class Door : MonoBehaviour
{
    private Animation _animation;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
    }

    public void Open()
    {
        _animation.Play();
    }
}