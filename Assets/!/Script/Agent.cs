using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Agent : MonoBehaviour
{
    Action<Ticket> myAction;

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
        public Ticket(float time, string name)
        {
            this.ElapsedTime = time;
            this.Name = name;
        }
    }

    private void Awake()
    {
        root = uiDocument.rootVisualElement;
        head = root.Q<Label>("head");
        body = root.Q<Label>("body");
        body = root.Q<Label>("foot");
    }

    private void CheakMyData()
    {
        //head.text = this.gameObject.name;
        //body.text = destination.ToString();
        //foot.text = agent.speed.ToString();
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

    public void CheckStartTime()
    {
        startTime = Time.time;
    }

    void Update()
    {
        CheakMyData();

        if (destination == Vector3.zero) return;

        if (agent.remainingDistance < agent.stoppingDistance)
        {

            destination = Vector3.zero;
            elapsedTime = Time.time - startTime;
            
            Debug.Log("µµÂøÇÔ");
            myAction(new Ticket(elapsedTime, this.gameObject.name));

             agent.Warp(orignalPos);
        }
    }
}