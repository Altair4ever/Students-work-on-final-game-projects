using UnityEngine;
using System.Collections; // Required for IEnumerator

public class TakeDamage : MonoBehaviour
{
    private Animator animator;
    private bool isHurting = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamageAction()
    {
        if (!isHurting)
        {
            isHurting = true;
            animator.SetTrigger("Hit");
            StartCoroutine(ReturnToIdle());
        }
    }

    private IEnumerator ReturnToIdle()
    {
        yield return new WaitForSeconds(0.5f); // Duration of the HIT animation
        isHurting = false;
    }
}
