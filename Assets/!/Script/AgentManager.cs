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

    //public struct RankTicket
    //{
    //    public int Rank1, Rank2, Rank3, Rank4, Rank5, Rank6, Rank7;
    //    public string Name1, Name2, Name3, Name4, Name5, Name7;

    //    public RankTicket(int rank1, string name, GameObject obj)
    //    {
    //        this.ElapsedTime = time;
    //        this.Name = name;
    //        this.Obj = obj;
    //    }
    //}

    public string rank1, rank2, rank3, rank4, rank5, rank6, rank7;


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
        ////rank.Add(rankCounter++);
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
        rank1 = arrivalList[0].name;
        rank2 = arrivalList[1].name;
        rank3 = arrivalList[2].name;
        rank4 = arrivalList[3].name;
        rank5 = arrivalList[4].name;
        rank6 = arrivalList[5].name;
        rank7 = arrivalList[6].name;

        Debug.Log("=== 도착 순서 ===");
        for (int i = 0; i < arrivalList.Count; i++)
        {
            Debug.Log($"{i + 1} : {arrivalList[i].name}");
        }
    }
}