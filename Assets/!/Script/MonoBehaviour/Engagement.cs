using System;
using UnityEngine;

public class Engagement : MonoBehaviour
{
    [SerializeField] RadiusRenderer radiusRenderer;

    public GameObject bulletPrefab;
    public Transform player;
    public Transform firePoint;
    public Transform fireTarget;

    public float bulletSpeed = 20f;
    public float rotationSpeed = 5f;
    public float detectionRange = 15f;


    void Start()
    {
        if (player == null)
        {
            player = this.transform;
        }

        radiusRenderer.SetRadius(detectionRange);
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
                RotateTowardsTarget(player, nearestTarget, rotationSpeed);
                FireAtPoint(nearestTarget.transform.position);
            }
        }
        else
        {
            radiusRenderer.SetColor(Color.green);
        }
    }

    void RotateTowardsTarget(Transform player, Transform target, float rotationSpeed)
    {
        Vector3 direction = (target.position - player.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        player.rotation = Quaternion.Slerp(player.rotation, lookRotation, Time.deltaTime * rotationSpeed);
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

    public void FireAtPoint(Vector3 targetPoint)
    {
        Vector3 direction = (targetPoint - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = direction * bulletSpeed;

        Destroy(bullet, 1f);
    }   
}