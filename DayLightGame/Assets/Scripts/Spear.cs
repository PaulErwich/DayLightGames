using UnityEngine;

public class Spear : MeleeBase
{
    protected override void Awake()
    {
        type = EvolveTypeSword.Dagger;

        //damage = Spear Damage Here;
        //attackSpeed = Spear Attack Speed Here;
        //duration = Spear Bleed Duration;
    }

    public override void Enhance()
    {
        duration *= 2;
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
        //Triple Attack
    }

    public override void MeleeSpecial2()
    {
        //Increased Range
    }
}
