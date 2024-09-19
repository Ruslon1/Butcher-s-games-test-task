using System;
using UnityEngine.SceneManagement;

public class Gameplay : ContextBehaviour
{
    private void Start()
    {
        StartGameplay();
    }

    public void StartGameplay()
    {
        Context.LevelManager.NextLevel();
        Context.LevelManager.StartLevel();
    }

    public void FinishGameplay()
    {
        Context.ObservedAgent.Finish();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}