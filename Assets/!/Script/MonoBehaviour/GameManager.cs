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