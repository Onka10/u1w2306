using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    public FireWork fireworks;
    public int childParticleIndex;
    public Color newColor;
    public int newMaxParticles;
    public float newScale;

    private void Start()
    {
        // fireworks = GetComponent<Fireworks>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // fireworks.SetAllParticleProperties(newColor, newMaxParticles, newScale);
            fireworks.SetParentParticle(Color.red,500,0.5f);
            fireworks.SetAllChildParticle(Color.red,500);
        }
    }
}
