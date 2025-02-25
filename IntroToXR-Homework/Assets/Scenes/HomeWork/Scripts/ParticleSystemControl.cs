using UnityEngine;
    
public class ParticleSystemControl : MonoBehaviour
{
    private ParticleSystem waterParticles;
    public float triggerDegree = 20.0f;
    private float degrees;
    private bool isPlaying;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waterParticles = gameObject.GetComponent<ParticleSystem>();
        waterParticles.Stop();
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        degrees = Vector3.Angle(Vector3.up, transform.up);

        if (degrees > triggerDegree) {
            if (!isPlaying) {
                waterParticles.Play();
                isPlaying = true;
            }
        } else {
            if (isPlaying) {
                waterParticles.Stop();
                isPlaying = false;
            }
        }
    }
}

