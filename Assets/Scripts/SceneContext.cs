using System;
using ButchersGames;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public LevelManager LevelManager;
    [HideInInspector] public Agent ObservedAgent;
    public SceneCamera SceneCamera { get; private set; }
    public Gameplay Gameplay { get; private set; }

    private void Awake()
    {
        SceneCamera = GetComponentInChildren<SceneCamera>();
        Gameplay = GetComponent<Gameplay>();
        
        ContextBehaviour[] behaviours = FindObjectsByType<ContextBehaviour>(FindObjectsSortMode.None);

        foreach (var behaviour in behaviours)
        {
            behaviour.Context = this;
        }
    }
}

public class ContextBehaviour : MonoBehaviour
{
    [HideInInspector] public SceneContext Context;
}