using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FinishMenuUI : ContextBehaviour
{
    private Image _win;
    [SerializeField] private GameObject[] _toDisable;

    private void Awake()
    {
        _win = GetComponentInChildren<Image>();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _win.rectTransform.DOPunchScale(Vector3.one, 10);

        foreach (var toDisable in _toDisable)
        {
            toDisable.SetActive(false);
        }
    }
}