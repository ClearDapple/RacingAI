using UnityEngine;

public class IdleState : IAgentState
{
    public void Enter(AgentAI agentAI)
    {
        agentAI.radiusRenderer.SetColor(Color.green);
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