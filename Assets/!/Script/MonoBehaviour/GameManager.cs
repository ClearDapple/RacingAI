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
        ////���� �����ֱ�

        ////���� ���ϱ�
        ////PlayerChoice�� AIChoice ��
    }

    private void RankingAgentsUI_OnGameResetEvent()
    {
        myPickSO.initialize();
    }
}