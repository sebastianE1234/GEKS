using UnityEngine;

public class windattack : MonoBehaviour
{
    public GameObject windAttackPrefab;
    public Transform shootPoint;
    public AudioClip windSound;
    public float shootForce = 20f;
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
            ShootWindAttack();
        }
    }

    void ShootWindAttack()
    {

        GameObject wind = Instantiate(windAttackPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = wind.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = shootPoint.forward * shootForce;
        }


        if (windSound != null)
        {
            audioSource.PlayOneShot(windSound);
        }
    }
}