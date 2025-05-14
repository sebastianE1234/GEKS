using UnityEngine;

public class bushblock : MonoBehaviour
{
    public AudioClip bushBlockSound;
    public float volume = 1.0f;
    public KeyCode bushBlockKey = KeyCode.J;
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
        if (Input.GetKeyDown(bushBlockKey))
        {
            PlayBlockSound();
        }
    }

    void PlayBlockSound()
    {
        if (bushBlockSound != null)
        {
            audioSource.PlayOneShot(bushBlockSound, volume);
        }
        else
        {
            Debug.LogWarning("Bush block sound not assinged. ");
        }
    }
}