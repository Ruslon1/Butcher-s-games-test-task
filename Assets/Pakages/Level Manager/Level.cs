using System;
using UnityEngine;

namespace ButchersGames
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private Agent _agentPrefab;

        private LevelManager _levelManager;

        private void Awake()
        {
            _levelManager = GetComponentInParent<LevelManager>();
        }

        private void OnEnable()
        {
            _levelManager.OnLevelStarted += LevelStarted;
        }

        private void OnDisable()
        {
            _levelManager.OnLevelStarted -= LevelStarted;
        }

        private void LevelStarted()
        {
            Agent agent = Instantiate(_agentPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
            agent.Context = _levelManager.Context;
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            if (playerSpawnPoint != null)
            {
                Gizmos.color = Color.magenta;
                var m = Gizmos.matrix;
                Gizmos.matrix = playerSpawnPoint.localToWorldMatrix;
                Gizmos.DrawSphere(Vector3.up * 0.5f + Vector3.forward, 0.5f);
                Gizmos.DrawCube(Vector3.up * 0.5f, Vector3.one);
                Gizmos.matrix = m;
            }
        }
#endif
    }
}