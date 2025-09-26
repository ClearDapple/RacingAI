
public class AttackState : IAgentState
{
    public void Enter(AgentAI agentAI)
    {
        //agentAI.radiusRenderer.SetColor(new AttackState());
    }
    public void Execute(AgentAI agentAI)
    {
        agentAI.RotateTowardsTarget();
    }
    public void Exit(AgentAI agentAI)
    {
        agentAI.FireAtPoint();
    }
}