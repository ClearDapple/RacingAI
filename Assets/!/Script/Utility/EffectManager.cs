using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject particlePrefab;
    public GameObject firePrefab;


    void Start()
    {
        Bullet.OnHitContactEvent += OnHitContactEvent;
    }

    public void OnHitContactEvent(Vector3 pos)
    {

        GameObject psInstance = Instantiate(particlePrefab, pos, Quaternion.identity);
        ParticleSystem ps = psInstance.GetComponent<ParticleSystem>();
        ps.Play();

        //Destroy(psInstance, ps.main.duration + ps.main.startLifetime.constant);
        Destroy(psInstance, 2f); 
    }

    private void OnDisable()
    {
        Bullet.OnHitContactEvent -= OnHitContactEvent;
    }
}