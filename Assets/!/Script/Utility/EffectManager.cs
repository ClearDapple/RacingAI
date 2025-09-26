using System;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EffectManager : MonoBehaviour
{
    //public GameObject firePrefab;
    public GameObject BulletHitParticle;
    public GameObject TurretDestroyParticle;
    public GameObject TurretCreateParticle;


    void Start()
    {
        Bullet.OnHitContactEvent += OnHitContactEvent;
        AgentAI.OnTurretDestroySelfEvent += OnTurretDestroySelfEvent;
        GameManager.OnCreateTurretEvent += OnCreateTurretEvent;
    }


    public void OnHitContactEvent(Vector3 pos)
    {
        GameObject psInstance = Instantiate(BulletHitParticle, pos, Quaternion.identity);
        ParticleSystem ps = psInstance.GetComponent<ParticleSystem>();
        ps.Play();

        //Destroy(psInstance, ps.main.duration + ps.main.startLifetime.constant);
        Destroy(psInstance, 2f); 
    }

    private void OnTurretDestroySelfEvent(Vector3 pos)
    {
        GameObject psInstance = Instantiate(TurretDestroyParticle, pos, Quaternion.identity);
        ParticleSystem ps = psInstance.GetComponent<ParticleSystem>();
        ps.Play();

        //Destroy(psInstance, ps.main.duration + ps.main.startLifetime.constant);
        Destroy(psInstance, 3f);
    }

    private void OnCreateTurretEvent(Vector3 pos)
    {
        GameObject psInstance = Instantiate(TurretCreateParticle, pos, Quaternion.identity);
        ParticleSystem ps = psInstance.GetComponent<ParticleSystem>();
        ps.Play();

        //Destroy(psInstance, ps.main.duration + ps.main.startLifetime.constant);
        Destroy(psInstance, 1.5f);
    }

    private void OnDisable()
    {
        Bullet.OnHitContactEvent -= OnHitContactEvent;
        AgentAI.OnTurretDestroySelfEvent -= OnTurretDestroySelfEvent;
    }
}