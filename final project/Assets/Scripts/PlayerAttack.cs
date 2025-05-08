using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TriggerAttackAnimation();
        }
    }

    void TriggerAttackAnimation()
    {
        animator.SetTrigger("AttackTrigger");
    }
}
