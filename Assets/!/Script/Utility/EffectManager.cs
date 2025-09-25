using UnityEngine;

public class EffectManager : MonoBehaviour
{
    //public GameObject firePrefab;
    public GameObject particlePrefab;
    public GameObject DestroyPrefab;


    void Start()
    {
        Bullet.OnHitContactEvent += OnHitContactEvent;
        AgentAI.OnTurretDestroySelfEvent += OnTurretDestroySelfEvent;
    }

    public void OnHitContactEvent(Vector3 pos)
    {
        GameObject psInstance = Instantiate(particlePrefab, pos, Quaternion.identity);
        ParticleSystem ps = psInstance.GetComponent<ParticleSystem>();
        ps.Play();

        //Destroy(psInstance, ps.main.duration + ps.main.startLifetime.constant);
        Destroy(psInstance, 2f); 
    }

    private void OnTurretDestroySelfEvent(Vector3 pos)
    {
        GameObject psInstance = Instantiate(DestroyPrefab, pos, Quaternion.identity);
        ParticleSystem ps = psInstance.GetComponent<ParticleSystem>();
        ps.Play();

        //Destroy(psInstance, ps.main.duration + ps.main.startLifetime.constant);
        Destroy(psInstance, 3f);
    }

    private void OnDisable()
    {
        Bullet.OnHitContactEvent -= OnHitContactEvent;
        AgentAI.OnTurretDestroySelfEvent -= OnTurretDestroySelfEvent;
    }
}