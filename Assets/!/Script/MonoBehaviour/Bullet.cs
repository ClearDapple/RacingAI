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
            Debug.Log("충돌한 오브젝트에 Agent 컴포넌트가 없습니다.");
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
            Debug.Log("충돌한 오브젝트에 Agent 컴포넌트가 없습니다.");
        }
    }
}