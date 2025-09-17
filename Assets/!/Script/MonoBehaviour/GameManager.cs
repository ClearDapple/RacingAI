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

            // 랜덤으로 하나 선택
            int randomIndex = Random.Range(0, availableNumbers.Length);
            return availableNumbers[randomIndex];
        }
    }
}