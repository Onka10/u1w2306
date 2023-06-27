using UnityEngine;
using UniRx;


public class FireWork : MonoBehaviour
{
    public FireworkData parentParticle;
    [SerializeField] private ParticleSystem parentParticleSystem;
    public ParticleSystem[] childParticleSystems;

    //背後削除の判定
    public bool InBack=false;

    private void Start()
    {
        // 親パーティクルのプロパティを設定する
        SetParticleProperties(parentParticleSystem, parentParticle);

        // 子パーティクルのプロパティを設定する
        foreach (var childParticleSystem in childParticleSystems)
        {
            SetParticleProperties(childParticleSystem, parentParticle);
        }

        DestroySelfAfterDelay(7f);
    }

    public void SetParentParticle(Color startColor, int maxParticles, float scale)
    {
        parentParticle.fireColor = startColor;
        parentParticle.maxParticles = maxParticles;
        parentParticle.scale = scale;

        SetParticleProperties(parentParticleSystem, parentParticle);
        SetParticleScale(parentParticleSystem, parentParticle);
    }

    public void SetAllChildParticle(Color startColor, int maxParticles)
    {
        foreach (var childParticleSystem in childParticleSystems)
        {
            var particleData = new FireworkData
            {
                fireColor = startColor,
                maxParticles = maxParticles,
                scale = parentParticle.scale
            };

            SetParticleProperties(childParticleSystem, particleData);
        }
    }

    private void SetParticleProperties(ParticleSystem particleSystem, FireworkData particleData)
    {
        var mainModule = particleSystem.main;
        mainModule.startColor = particleData.fireColor;
        mainModule.maxParticles = particleData.maxParticles;
    }

    private void SetParticleScale(ParticleSystem particleSystem, FireworkData particleData)
    {
        particleSystem.transform.localScale = new Vector3(particleData.scale, particleData.scale, particleData.scale);
    }

    private void DestroySelfAfterDelay(float delay)
    {
        Destroy(gameObject, delay);
    }
}
