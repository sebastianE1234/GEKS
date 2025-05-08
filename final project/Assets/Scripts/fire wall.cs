using UnityEngine;

public class firewall : MonoBehaviour
{
    public GameObject firewallPrefab;
    public Transform summonPoint;
    public AudioClip fireSound;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SummonFireWall();
        }
    }
    void SummonFireWall()
    {
        Instantiate(firewallPrefab, summonPoint.position, summonPoint.rotation);
        PlayFireSound();
    }
    void PlayFireSound()
    {
        if (fireSound != null)
        {
            audioSource.clip = fireSound;
            audioSource.Play();
        }
    }
}