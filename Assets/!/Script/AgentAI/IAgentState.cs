public interface IAgentState
{
    void Enter(AgentAI agentAI);
    void Execute(AgentAI agentAI);
    void Exit(AgentAI agentAI);
}