using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] MyPickSO myPickSO;
    [SerializeField] Camera mainCamera;

    [SerializeField] UIManager uiManager;
    [SerializeField] AgentManager agentManager;

    [SerializeField] Transform endPointPos;

    private void Awake()
    {
        AgentConfirmUI.OnGamePlayStartEvent += AgentConfirmUI_OnGamePlayStartEvent;
        RankingAgentsUI.OnGameResetEvent += RankingAgentsUI_OnGameResetEvent;
    }

    public void AgentConfirmUI_OnGamePlayStartEvent()
    {
        agentManager.StartToRun(endPointPos.position);
    }

    public void OnGamePlayEndEvent()
    {
        ////순위 보여주기

        ////승패 정하기
        ////PlayerChoice와 AIChoice 비교
    }

    private void RankingAgentsUI_OnGameResetEvent()
    {
        myPickSO.initialize();
    }
}