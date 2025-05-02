using UnityEngine;

public class Audioscript : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform shootPoint;
    public AudioClip fireballSound;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {

        Instantiate(fireballPrefab, shootPoint.position, shootPoint.rotation);

        if (fireballSound != null)
        {
            audioSource.PlayOneShot(fireballSound);

        }
        else
        {
            Debug.LogWarning("Fireball sound or AudioSource is missing");
        }
    }
}