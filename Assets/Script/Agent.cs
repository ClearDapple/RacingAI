using System;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    Action<Ticket> myAction;
    public Vector3 destination = Vector3.zero;
    public Vector3 orignalPos;
    public NavMeshAgent agent;
    public float startTime;
    public float elapsedTime;


    public struct Ticket
    {
        public float ElapsedTime;
        public string Name;
        public Ticket(float time, string name)
        {
            this.ElapsedTime = time;
            this.Name = name;
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        orignalPos = transform.position;
    }

    public void Setup(float speed, Vector3 des)
    {
        destination = des;

        agent.speed = speed;
        agent.destination = des;
    }

    public void CallbackAction(Action<Ticket> action)
    {
        myAction = action;
    }

    void Update()
    {
        if (destination == Vector3.zero) return;

        if (agent.remainingDistance < agent.stoppingDistance)
        {

            destination = Vector3.zero;
            elapsedTime = Time.time - startTime;
            
            Debug.Log("µµÂøÇÔ");
            myAction(new Ticket(elapsedTime, this.gameObject.name));

            transform.position = orignalPos;
            agent.SetDestination(orignalPos);
        }
    }
}