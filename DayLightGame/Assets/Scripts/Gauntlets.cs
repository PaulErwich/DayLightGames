using UnityEngine;

public class Gauntlets : MeleeBase
{
    protected override void Awake()
    {
        type = EvolveTypeSword.Dagger;

        //damage = Dagger Damage Here;
        //attackSpeed = Dagger Attack Speed Here;
        //duration = Gauntlets Slow Duration;
    }

    public override void Enhance()
    {
        //Dual hit on third attack
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
        //Double Dash Distance
    }

    public override void MeleeSpecial2()
    {
        //Apply Electric On Hit
    }
}
