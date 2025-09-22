using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameManager particlePrefab;
    public GameObject firePrefab;

    private void Start()
    {
       // Bullet.OnHitContactEvent += Bullet_OnHitContactEvent;
    }

    /*
    private void Bullet_OnHitContactEvent(Vector3 position)
    {
        GameObject psInstance = Instantiate(particlePrefab, position, Quaternion.identity);
        ParticleSystem ps = psInstance.GetComponent<ParticleSystem>();
    }
    */
}
