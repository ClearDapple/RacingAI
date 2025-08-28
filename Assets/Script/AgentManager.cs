using System.Collections;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using static Agent;
using Random = UnityEngine.Random;

public class AgentManager: MonoBehaviour
{
    public Agent[] agents;
    public Queue agentQueue = new Queue();


    public void StartToRun(Vector3 pos)
    {
        agentQueue.Clear();

        foreach (var item in agents)
        {
            float speed = Random.Range(10f, 50f);
            Vector3 des = pos;
            item.Setup(speed, pos);
            item.CallbackAction(MyAction);
        }
    }

    private void MyAction(Ticket obj)
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
        }
    }
}