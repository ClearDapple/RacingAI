using UnityEngine;

public class DeadState : IAgentState
{
    public void Enter(AgentAI agentAI)
    {
        agentAI.radiusRenderer.SetColor(Color.gray);
    }
    public void Execute(AgentAI agentAI)
    {
        //null
    }
    public void Exit(AgentAI agentAI)
    {
        //null
    }
}