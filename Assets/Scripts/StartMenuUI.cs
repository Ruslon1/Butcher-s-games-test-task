using System;
using UnityEngine.InputSystem;

public class StartMenuUI : ContextBehaviour
{
    public void Hide()
    {
        Context.ObservedAgent.PermitMove();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Touchscreen.current.wasUpdatedThisFrame)
        {
            Hide();
        }
    }
}