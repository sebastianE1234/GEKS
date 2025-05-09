using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;

    // Set this to match your attack animation's duration
    public float attackDuration = 1.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && !isAttacking)
        {
            isAttacking = true;
            animator.SetBool("isAttacking", true);

            // Start a coroutine to reset the animation after it finishes
            StartCoroutine(ResetAttack());
        }
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(attackDuration);
        isAttacking = false;
        animator.SetBool("isAttacking", false);
    }
}
