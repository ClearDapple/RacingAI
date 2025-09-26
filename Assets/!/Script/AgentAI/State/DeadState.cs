
public class DeadState : IAgentState
{
    public void Enter(AgentAI agentAI)
    {
        //agentAI.radiusRenderer.SetColor(new DeadState());
    }
    public void Execute(AgentAI agentAI)
    {
        agentAI.DestroySelf();
    }
    public void Exit(AgentAI agentAI)
    {
        //null
    }
}