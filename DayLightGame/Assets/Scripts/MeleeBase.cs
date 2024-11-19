using Unity.VisualScripting;
using UnityEngine;

public class MeleeBase : MonoBehaviour
{
    private Animator animator;
    EvolveTypeSword evolve;
    public EvolveTypeSword type = EvolveTypeSword.Default;
    private BoxCollider2D bc;

    [Header("Upgrades")]
    public bool meleeSpecial1;
    public bool meleeSpecial2;
    public bool enhance;
    public bool damageUp;
    public string element;
    public int elementDamage;

    [Header("Stats")]
    public int damage = 2;
    public float attackSpeed = 3;
    public float duration = 3;
    public int slowAmount = 0;

    private float cooldown;
    public string swingType = "slash";

    protected virtual void Awake()
    {
        animator = GetComponentInParent<Animator>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        cooldown += Time.deltaTime;
    }

    public void Hit()
    {
        if (cooldown >= 1 / attackSpeed)
        {
            animator.SetTrigger(swingType);
            cooldown = 0;
        }
    }

    public EvolveTypeSword GetEvolveType()
    {
        return evolve;
    }

    public virtual void Enhance()
    {

    }

    public virtual void Damage()
    {

    }

    public virtual void AttackSpeed()
    {

    }

    public virtual void MeleeSpecial1()
    {

    }

    public virtual void MeleeSpecial2()
    {

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