using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] AgentManager agentManager;
    [SerializeField] Transform endPointPos;


    public void OnGamePlayStartEvent()
    {
        agentManager.StartToRun(endPointPos.position);
    }
}
/*
if (Input.GetMouseButtonDown(0))
{
Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

RaycastHit hit;

if (Physics.Raycast(ray, out hit))
{
    Vector3 pos = hit.point;

    pos.y = 0f;

    agentManager.StartToRun(pos);
}
}
*/