using UnityEngine;

public class AgentAI : MonoBehaviour
{
    IAgentState currentState;

    public RadiusRenderer radiusRenderer;

    public GameObject bulletPrefab;
    public Transform player;
    public Transform firePoint;
    public Transform fireTarget;

    public float bulletSpeed = 20f;
    public float rotationSpeed = 5f;

    public float detectionRange = 10f;
    public int bulletCount = 10;

    void Start()
    {
        if (player == null)
        {
            player = this.transform;
        }
        radiusRenderer.SetRadius(detectionRange);
        ChangeState(new IdleState());
    }

    void Update()
    {
        Transform nearestTarget = FindNearestTarget(player);

        if (nearestTarget == null) return;

        float distanceToNearest = Vector3.Distance(player.position, nearestTarget.position);

        if (distanceToNearest <= detectionRange)
        {
            radiusRenderer.SetColor(Color.red);

            if (Input.GetMouseButtonDown(0)) // Left click
            {
                //atcakk
            }
        }
    }

    Transform FindNearestTarget(Transform player)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Agent");
        Transform nearestTarget = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(player.position, target.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestTarget = target.transform;
            }
        }
        return nearestTarget;
    }

    public void RotateTowardsTarget()
    {
        Transform player = this.transform;
        Vector3 target = FindNearestTarget(gameObject.transform).position;

        Vector3 direction = (target - player.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        player.rotation = Quaternion.Slerp(player.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public void FireAtPoint()
    {
        Vector3 targetPoint = FindNearestTarget(gameObject.transform).position;

        Vector3 direction = (targetPoint - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = direction * bulletSpeed;

        Destroy(bullet, 1f);
    }

    public void ChangeState(IAgentState newState)
    {
        currentState?.Exit(this);

        currentState = newState;
        currentState?.Enter(this);
        currentState?.Execute(this);
    }

    public bool IsTargetNearby()
    {
        bool isNearby = false;

        if (true) { isNearby = true; }
        else { isNearby = false; }
        //로직 추가
        return isNearby;
    }

    public bool IsTargetCloseEnough()
    {
        bool isCloseEnough = false;

        if (true) { isCloseEnough = true; }
        else { isCloseEnough = false; }
        //로직 추가
        return isCloseEnough;
    }

    public void PerformAttack()
    {
        //공격
    }

    public void DestroySelf()
    {
        //Destroy(gameObject);
    }
}