using UnityEngine;
using UniRx;

[System.Serializable]
public class ParticleData
{
    public Color startColor;
    public int maxParticles;
    public float scale;
}

public class FireWork : MonoBehaviour
{
    public ParticleData parentParticle;
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
        parentParticle.startColor = startColor;
        parentParticle.maxParticles = maxParticles;
        parentParticle.scale = scale;

        SetParticleProperties(parentParticleSystem, parentParticle);
        SetParticleScale(parentParticleSystem, parentParticle);
    }

    // public void SetChildParticle(int particleIndex, Color startColor, int maxParticles)
    // {
    //     if (particleIndex < 0 || particleIndex >= childParticleSystems.Length)
    //     {
    //         Debug.LogError("Invalid particle index.");
    //         return;
    //     }

    //     var particleData = new ParticleData
    //     {
    //         startColor = startColor,
    //         maxParticles = maxParticles,
    //         scale = parentParticle.scale
    //     };

    //     SetParticleProperties(childParticleSystems[particleIndex], particleData);
    // }

    public void SetAllChildParticle(Color startColor, int maxParticles)
    {
        foreach (var childParticleSystem in childParticleSystems)
        {
            var particleData = new ParticleData
            {
                startColor = startColor,
                maxParticles = maxParticles,
                scale = parentParticle.scale
            };

            SetParticleProperties(childParticleSystem, particleData);
        }
    }

    private void SetParticleProperties(ParticleSystem particleSystem, ParticleData particleData)
    {
        var mainModule = particleSystem.main;
        mainModule.startColor = particleData.startColor;
        mainModule.maxParticles = particleData.maxParticles;
    }

    private void SetParticleScale(ParticleSystem particleSystem, ParticleData particleData)
    {
        particleSystem.transform.localScale = new Vector3(particleData.scale, particleData.scale, particleData.scale);
    }

    private void DestroySelfAfterDelay(float delay)
    {
        Destroy(gameObject, delay);
    }
}
