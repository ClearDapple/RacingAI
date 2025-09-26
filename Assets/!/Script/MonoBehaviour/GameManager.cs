using System;
using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static event Action<Vector3> OnCreateTurretEvent;

    [SerializeField] MyPickSO myPickSO;
    [SerializeField] Camera mainCamera;

    [SerializeField] UIManager uiManager;
    [SerializeField] AgentManager agentManager;

    [SerializeField] Transform endPointPos;//��������
    [SerializeField] GameObject TurretPrefab;
    [SerializeField] Transform[] turretSpawnPointPosArry;


    private void Awake()
    {
        AgentConfirmUI.OnGamePlayStartEvent += AgentConfirmUI_OnGamePlayStartEvent;
        RankingAgentsUI.OnGameResetEvent += RankingAgentsUI_OnGameResetEvent;
    }

    public void AgentConfirmUI_OnGamePlayStartEvent()
    {
        StartCoroutine(CreateTurret());
    }

    IEnumerator CreateTurret()
    {
        for (int i = 0; i < turretSpawnPointPosArry.Length; i++)
        {
            Vector3 pos = turretSpawnPointPosArry[i].position;
            yield return new WaitForSeconds(0.5f);

            GameObject clone = Instantiate(TurretPrefab, pos, Quaternion.identity);
            OnCreateTurretEvent?.Invoke(pos);//effect&sound
        }
        yield return new WaitForSeconds(3f);
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