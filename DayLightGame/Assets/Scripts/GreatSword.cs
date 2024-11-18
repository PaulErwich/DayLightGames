using UnityEngine;

public class GreatSword : MeleeBase
{
    protected override void Awake()
    {
        type = EvolveTypeSword.Dagger;

        //damage = Great Sword Damage Here;
        //attackSpeed = Great Sword Attack Speed Here;
    }

    public override void Enhance()
    {
        //Increased Range
    }

    public override void Damage()
    {
        //+X Damage
    }

    public override void AttackSpeed()
    {
        //+Y Attack Speed
    }

    public override void MeleeSpecial1()
    {
        //Chance To Crit
    }

    public override void MeleeSpecial2()
    {
        //Destroy Projectiles
    }
}
