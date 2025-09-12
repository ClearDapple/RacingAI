using System.Collections;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] AgentManager agentManager;
    [SerializeField] Transform endPointPos;

    public int PlayerChoice = 0;
    public int AIChoice = 0;

    public void OnGamePlayStartEvent()
    {
        agentManager.StartToRun(endPointPos.position);
    }

    public void selectAgentNumber()
    {
        int randomNum = GetRandomNumberExcluding(PlayerChoice);
        AIChoice = randomNum;
    }

    int GetRandomNumberExcluding(int excludedNumber)
    {
        int[] availableNumbers = new int[6];
        int index = 0;

        for (int i = 1; i <= 7; i++)
        {
            if (i != excludedNumber)
            {
                availableNumbers[index] = i;
                index++;
            }
        }

        // 랜덤으로 하나 선택
        int randomIndex = Random.Range(0, availableNumbers.Length);
        return availableNumbers[randomIndex];
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