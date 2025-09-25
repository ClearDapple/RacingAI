
public class  AlertState : IAgentState
{
    public void Enter(AgentAI agentAI)
    {
        agentAI.radiusRenderer.SetColor(new AlertState());
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