using System.Collections;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    [SerializeField] MyPickSO myPickSO;
    [SerializeField] Camera mainCamera;
    [SerializeField] UIManager uiManager;
    [SerializeField] AgentManager agentManager;
    [SerializeField] Transform endPointPos;

    private void Start()
    {
        initialize();
    }

    public void initialize()
    {

    }

    public void OnGamePlayStartEvent()
    {
        agentManager.StartToRun(endPointPos.position);
    }

    public void OnGamePlayEndEvent()
    {

        ////순위 보여주기


        ////승패 정하기
        ////PlayerChoice와 AIChoice 비교
    }

    
}