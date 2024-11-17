using Unity.VisualScripting;
using UnityEngine;

public class Sword : MeleeBase
{
    private Animator animator;
    private BoxCollider2D bc;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        bc = gameObject.AddComponent<BoxCollider2D>();
        bc.isTrigger = true;
        bc.enabled = true;
    }

    public void Swing()
    {
        animator.SetTrigger("SwordSwing");
    }
}
