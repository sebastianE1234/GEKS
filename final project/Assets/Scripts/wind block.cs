using UnityEngine;

public class windblock : MonoBehaviour
{
    public AudioClip windBlockSound;
    public float volume = 1.0f;
    public KeyCode windBlockKey = KeyCode.G;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(windBlockKey))
        {
            PlayWindBlockSound();
        }
    }

    void PlayWindBlockSound()
    {
        if (windBlockSound != null)
        {
            audioSource.PlayOneShot(windBlockSound, volume);
        }
        else
        {
            Debug.LogWarning("Wind block sound not assigned.");
        }
    }
}