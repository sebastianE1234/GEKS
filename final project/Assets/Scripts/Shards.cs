using UnityEngine;

public class Shards : MonoBehaviour
{
    public GameObject shardPrefab;
    public Transform shootPoint;
    public AudioClip shardSound;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootShard();
        }
    }

    void ShootShard()
    {
        Instantiate(shardPrefab, shootPoint.position, shootPoint.rotation);

        if (shardSound != null)
        {
            audioSource.PlayOneShot(shardSound);
        }
    }
}
