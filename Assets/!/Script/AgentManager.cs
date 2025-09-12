using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Events;
using static Agent;
using Random = UnityEngine.Random;

public class AgentManager: MonoBehaviour
{
    public UnityEvent OnGamePlayEndEvent;

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
        ////rank.Add();
        arrivalList.Add(ticket.Obj);
        Debug.Log($"{arrivalList.Count} : {ticket.Name}({ticket.ElapsedTime})");
        CheckAllAgents();
    }

    private void CheckAllAgents()
    {
        if (agentQueue.Count == agents.Length)
        {
            int index = arrivalList.IndexOf(gameObject);  //자기자신의 도착순서 확인
            ////int rank = index + 1; //순위는 인덱스 + 1
            Debug.Log("전부 도착함");
            PrintArrivalOrder();
            OnGamePlayEndEvent?.Invoke();
        }
    }

    public void PrintArrivalOrder()//도착순서 출력
    {
        Debug.Log("=== 도착 순서 ===");
        for (int i = 0; i < arrivalList.Count; i++)
        {
            Debug.Log($"{i + 1} : {arrivalList[i].name}");
        }
    }
}