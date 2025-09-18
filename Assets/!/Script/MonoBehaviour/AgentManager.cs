using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using static Agent;
using Random = UnityEngine.Random;

public class AgentManager: MonoBehaviour
{
    public UnityEvent OnGamePlayEndEvent;

    [SerializeField] MyPickSO myPickSO;
    private List<GameObject> arrivalList = new List<GameObject>();
    private List<int> rank;

    public Agent[] agents;
    public Queue agentQueue = new Queue();


    public void StartToRun(Vector3 pos)
    {
        arrivalList.Clear();
        agentQueue.Clear();
        StartCoroutine(StartOneByOne(pos));
    }

    IEnumerator StartOneByOne(Vector3 pos)
    {
        foreach (var agent in agents)
        {
            yield return null;
            float speed = Random.Range(10f, 50f);
            agent.Setup(speed, pos);
            agent.CheckStartTime();
            agent.CallbackAction(CollectAgets);
            yield return null;
        }
    }

    private void CollectAgets(Ticket ticket)
    {
        agentQueue.Enqueue(ticket);
        arrivalList.Add(ticket.Obj);
        Debug.Log($"{arrivalList.Count} : {ticket.Name}({ticket.ElapsedTime})");
        CheckAllAgents();
    }

    private void CheckAllAgents()
    {
        if (agentQueue.Count == agents.Length)
        {
            Debug.Log("전부 도착함");
            int index = 0;
            foreach (Ticket ticket in agentQueue)
            {
                if (myPickSO.PlayerName == ticket.Name)
                {
                    myPickSO.PlayerRank = index + 1;
                    Debug.Log($"{ticket.Name}의 순위는 {myPickSO.PlayerRank}입니다.");
                    //leaderboardRacingAI.uploadScore(index.ToString());
                    break;
                }
                index++;
            }
            //TODO;  List<MyData> data
            // ShowRanking(data);

            agentQueue.Clear();
            OnGamePlayEndEvent?.Invoke();
        }
    }
}