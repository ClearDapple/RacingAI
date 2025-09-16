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

        ////���� �����ֱ�


        ////���� ���ϱ�
        ////PlayerChoice�� AIChoice ��
    }

    public void SelectAgentNumber(string playerAgentName)
    {
        int playerAgentNumber = int.Parse(name.Split('_')[1]);

        int randomNumber = GetRandomNumberExcluding(playerAgentNumber);

        if (randomNumber < 10)
        {
            myPickSO.AIName = $"Agent_0{randomNumber}";
        }
        else
        {
            myPickSO.AIName = $"Agent_{randomNumber}";
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

            // �������� �ϳ� ����
            int randomIndex = Random.Range(0, availableNumbers.Length);
            return availableNumbers[randomIndex];
        }
    }
}