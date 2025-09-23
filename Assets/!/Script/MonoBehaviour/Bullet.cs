using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static event Action<Vector3> OnHitContactEvent;

    void OnCollisionEnter(Collision collision)
    {
        try
        {
            collision.gameObject.GetComponent<Agent>().Speed--;
            collision.gameObject.GetComponent<TargetWobble>().TriggerWobble();
            OnHitContactEvent?.Invoke(collision.gameObject.transform.position);
        }
        catch (Exception)
        {
            Debug.Log("�浹�� ������Ʈ�� Agent ������Ʈ�� �����ϴ�.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            other.gameObject.GetComponent<Agent>().Speed--;
            other.gameObject.GetComponent<TargetWobble>().TriggerWobble();
            OnHitContactEvent?.Invoke(other.gameObject.transform.position);
        }
        catch (Exception)
        {
            Debug.Log("�浹�� ������Ʈ�� Agent ������Ʈ�� �����ϴ�.");
        }
    }
}