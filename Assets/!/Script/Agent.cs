using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Agent : MonoBehaviour
{
    Action<Ticket> agentCallbackAction;

    [SerializeField] private UIDocument uiDocument;
    private VisualElement root;
    private Label head, body, foot;

    public Vector3 destination = Vector3.zero;
    public Vector3 orignalPos;
    public NavMeshAgent agent;
    public float startTime;
    public float elapsedTime;


    public struct Ticket
    {
        public float ElapsedTime;
        public string Name;
        public GameObject Obj;

        public Ticket(float time, string name, GameObject obj)
        {
            this.ElapsedTime = time;
            this.Name = name;
            this.Obj = obj;
        }
    }

    private void Awake()
    {
        root = uiDocument.rootVisualElement;
        head = root.Q<Label>("head");
        body = root.Q<Label>("body");
        body = root.Q<Label>("foot");
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
        agentCallbackAction = action;
    }

    public void CheckStartTime()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (destination == Vector3.zero) return;

        if (agent.remainingDistance < agent.stoppingDistance)
        {
            destination = Vector3.zero;
            elapsedTime = Time.time - startTime;
            
            Debug.Log("µµÂøÇÔ");
            agentCallbackAction(new Ticket(elapsedTime, this.gameObject.name, this.gameObject));

             agent.Warp(orignalPos);
        }
    }
}