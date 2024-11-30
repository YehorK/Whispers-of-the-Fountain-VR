using UnityEngine;
/*
 * This Script handles the particle system above the fountain.
 * It mainly control its color (white) and rotation.
 */

public class SparkleEffectController : MonoBehaviour
{
    void Start()
    {
        // Get the Particle System or Add one if not present
        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();
        if (particleSystem == null)
        {
            particleSystem = gameObject.AddComponent<ParticleSystem>();
        }

        // Configure the main module
        var mainModule = particleSystem.main;
        mainModule.startSize = 0.1f; // Size of the sparkles
        mainModule.startColor = new ParticleSystem.MinMaxGradient(Color.white,  new Color(0.9f, 0.9f, 0.9f)); 
        mainModule.simulationSpace = ParticleSystemSimulationSpace.Local;

        // Configure emission
        var emissionModule = particleSystem.emission;
        emissionModule.rateOverTime = 50; // Sparkles per second

        // Configure shape
        var shapeModule = particleSystem.shape;
        shapeModule.shapeType = ParticleSystemShapeType.Donut; // Sparkles in a circular area
        shapeModule.radius = 0.5f; // Adjust to the plane size

        // Optional: Enable glowing sparkles
        var renderer = particleSystem.GetComponent<ParticleSystemRenderer>();
        renderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));
    }

    void Update()
    {
        // Optional: Rotate the sparkle effect or move it dynamically
        transform.Rotate(0, 30 * Time.deltaTime, 0); // Rotate the effect for visual flair
    }
}
