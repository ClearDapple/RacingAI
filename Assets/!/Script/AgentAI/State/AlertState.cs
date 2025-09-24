using UnityEngine;

public class  AlertState : IAgentState
{
    public void Enter(AgentAI agentAI)
    {
        agentAI.radiusRenderer.SetColor(Color.yellow);
    }
    public void Execute(AgentAI agentAI)
    {
        agentAI.RotateTowardsTarget();
    }
    public void Exit(AgentAI agentAI)
    {
        //null
    }
}