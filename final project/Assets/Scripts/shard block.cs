using UnityEngine;

public class shardblock : MonoBehaviour
{
    public AudioClip shardBlockSound;
    public float volume = 1.0f;
    public KeyCode shardBlockKey = KeyCode.H;
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
        if (Input.GetKeyDown(shardBlockKey))
        {
            PlayShardBlockSound();
        }
    }

    void PlayShardBlockSound()
    {
        if (shardBlockSound != null)
        {
            audioSource.PlayOneShot(shardBlockSound, volume);
        }
        else
        {
            Debug.LogWarning("Shard block sound not assigned");
        }
    }
}