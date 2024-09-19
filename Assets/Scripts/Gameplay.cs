using System;

public class Gameplay : ContextBehaviour
{
    private void Start()
    {
        StartGameplay();
    }

    private void StartGameplay()
    {
        Context.LevelManager.NextLevel();
        Context.LevelManager.StartLevel();
    }

    public void FinishGameplay()
    {
        Context.ObservedAgent.Finish();
    }
}