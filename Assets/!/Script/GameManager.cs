using System.Collections;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] UIManager uiManager;
    [SerializeField] AgentManager agentManager;
    [SerializeField] Transform endPointPos;

    public int intPlayerChoice;
    public int intAIChoice;
    public string strPlayerChoice;
    public string strAIChoice;
    public string scoreBoard;

    private void Start()
    {
        initialize();
    }

    public void initialize()
    {
        intPlayerChoice = 0;
        intAIChoice = 0;
        strPlayerChoice = "";
        strAIChoice = "";
        scoreBoard = "";
    }

    public void OnGamePlayStartEvent()
    {
        agentManager.StartToRun(endPointPos.position);
    }

    public void OnGamePlayEndEvent()
    {
        //string a1 = agentManager.rank1;
        //string a2 = agentManager.rank2;
        //string a3 = agentManager.rank3;
        //string a4 = agentManager.rank4;
        //string a5 = agentManager.rank5;
        //string a6 = agentManager.rank6;
        //string a7 = agentManager.rank7;

        //uiManager.ScoreBoardText(a1, a2, a3, a4, a5, a6, a7);
        //scoreBoard = $"1st ----- {agentManager.rank1}\r\n"
        //           + $"2nd ----- {agentManager.rank2}\r\n"
        //           + $"3rd ----- {agentManager.rank3}\r\n"
        //           + $"4th ----- {agentManager.rank4}\r\n"
        //           + $"5th ----- {agentManager.rank5}\r\n"
        //           + $"6th ----- {agentManager.rank6}\r\n"
        //           + $"7th ----- {agentManager.rank7}";

        ////순위 보여주기


        ////승패 정하기
        ////PlayerChoice와 AIChoice 비교

    }

    public void selectAgentNumber()
    {
        int randomNum = GetRandomNumberExcluding(intPlayerChoice);
        intAIChoice = randomNum;
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