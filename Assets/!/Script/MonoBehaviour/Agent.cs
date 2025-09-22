using System;
using Unity.Android.Gradle;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Agent : MonoBehaviour
{
    Action<Ticket> agentCallbackAction;

    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private Sprite sp;
    private VisualElement root;
    private Label head, body, foot;

    public Vector3 destination = Vector3.zero;
    public Vector3 orignalPos;
    public NavMeshAgent agent;
    public float startTime;
    public float elapsedTime;

    private int speed;
    public int Speed
    {
        get { return speed; }
        set
        {

        }
    }


    public struct Ticket
    {
        public float ElapsedTime;
        public string Name;
        public Sprite Img;

        public Ticket(float time, string name, Sprite img)
        {
            this.ElapsedTime = time;
            this.Name = name;
            this.Img = img;
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
            agentCallbackAction(new Ticket(elapsedTime, this.gameObject.name, sp));

             agent.Warp(orignalPos);
        }
    }
}