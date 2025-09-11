using System.Collections;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Events;
using static Agent;
using Random = UnityEngine.Random;

public class AgentManager: MonoBehaviour
{
    public UnityEvent OnGamePlayEndEvent;

    public Agent[] agents;
    public Queue agentQueue = new Queue();


    public void StartToRun(Vector3 pos)
    {
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

    private void CollectAgets(Ticket obj)
    {
        agentQueue.Enqueue(obj);

        Debug.Log("My Name?: " + obj.Name);
        Debug.Log("During Time?: " + obj.ElapsedTime);

        CheckAllAgents();
    }

    private void CheckAllAgents()
    {
        if (agentQueue.Count == agents.Length)
        {
            Debug.Log("전부 도착함");
            OnGamePlayEndEvent?.Invoke();
        }
    }
}