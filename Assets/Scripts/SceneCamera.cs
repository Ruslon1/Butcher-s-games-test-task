using UnityEngine;

public class SceneCamera : ContextBehaviour
{
    [SerializeField] private Vector3 _agentOffset;
    
    public void AttachToAgent()
    {
        transform.SetParent(Context.ObservedAgent.transform);
        transform.localPosition += _agentOffset;
    }
}