using UnityEngine;

public class JumpAnim : MonoBehaviour
{
    private Animator animator;
    public float previousYPosition;
    private void JumpAnimation()
    {

        float currentYPosition = Moove.singleton.rb.position.y;
        if (Moove.singleton.isOnPlatform == true)
        {
            animator.SetInteger("jump", 0);
        }
        else
        {
            // Сравниваем текущую координату "y" с предыдущей
            if (currentYPosition > previousYPosition)
            {
                animator.SetInteger("jump", 1);
            }
            else if (currentYPosition < previousYPosition)
            {
                animator.SetInteger("jump", -1);
            }

            previousYPosition = currentYPosition;
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        previousYPosition = Moove.singleton.rb.position.y;
    }
    private void Update()
    {
        animator.SetBool("isOnPlatform", Moove.singleton.isOnPlatform);
        JumpAnimation();
    }
}
