using Unity.VisualScripting;
using UnityEngine;

public class MeleeBase : MonoBehaviour
{
    private Animator animator;
    EvolveTypeSword evolve;
    public EvolveTypeSword type = EvolveTypeSword.Default;
    public BoxCollider2D bc;

    [Header("Upgrades")]
    public bool meleeSpecial1;
    public bool meleeSpecial2;
    public bool enhance;
    public bool damageUp;

    [Header("Stats")]
    public int damage = 2;
    public float attackSpeed = 1;
    public float duration = 3;
    public int slowAmount = 0;

    protected virtual void Awake()
    {
        animator = GetComponentInParent<Animator>();
        bc = gameObject.AddComponent<BoxCollider2D>();
    }

    public void Swing()
    {
        animator.SetTrigger("SwordSwing");
    }
}
public enum EvolveTypeSword
{
    Default = 0,
    Gauntlets = 1,
    Shield = 2,
    Dagger = 3,
    Spear = 4,
    Axe = 5,
    GreatSword = 6
}