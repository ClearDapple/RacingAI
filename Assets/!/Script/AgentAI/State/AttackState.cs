using UnityEditor;
using UnityEngine;

public class AttackState : IAgentState
{
    public void Enter(AgentAI agentAI)
    {
        agentAI.radiusRenderer.SetColor(Color.red);
        agentAI.bulletCount--;
    }
    public void Execute(AgentAI agentAI)
    {
        agentAI.RotateTowardsTarget();
        agentAI.FireAtPoint();
    }
    public void Exit(AgentAI agentAI)
    {
        //null
    }
}