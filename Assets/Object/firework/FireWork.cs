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

        LaunchManager.I.G
        .Subscribe(_ => Die())
        .AddTo(this);
    }

    public void SetParentParticleProperties(Color startColor, int maxParticles, float scale)
    {
        parentParticle.startColor = startColor;
        parentParticle.maxParticles = maxParticles;
        parentParticle.scale = scale;

        UpdateParticleSystem(parentParticleSystem, parentParticle);
    }

    public void SetChildParticleProperties(int particleIndex, Color startColor, int maxParticles)
    {
        if (particleIndex < 0 || particleIndex >= childParticleSystems.Length)
        {
            Debug.LogError("Invalid particle index.");
            return;
        }

        var particleData = new ParticleData
        {
            startColor = startColor,
            maxParticles = maxParticles,
            scale = parentParticle.scale
        };

        UpdateParticleSystem(childParticleSystems[particleIndex], particleData);
    }

    public void SetAllChildParticleProperties(Color startColor, int maxParticles)
    {
        foreach (var childParticleSystem in childParticleSystems)
        {
            var particleData = new ParticleData
            {
                startColor = startColor,
                maxParticles = maxParticles,
                scale = parentParticle.scale
            };

            UpdateParticleSystem(childParticleSystem, particleData);
        }
    }

    private void SetParticleProperties(ParticleSystem particleSystem, ParticleData particleData)
    {
        var mainModule = particleSystem.main;
        mainModule.startColor = particleData.startColor;
        mainModule.maxParticles = particleData.maxParticles;

        particleSystem.transform.localScale = new Vector3(particleData.scale, particleData.scale, particleData.scale);
    }

    private void UpdateParticleSystem(ParticleSystem particleSystem, ParticleData particleData)
    {
        SetParticleProperties(particleSystem, particleData);
    }

    void Die(){
        if(InBack)        Destroy(gameObject);
    }
}
