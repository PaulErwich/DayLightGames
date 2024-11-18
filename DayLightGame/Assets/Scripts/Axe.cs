using UnityEngine;

public class Axe : MeleeBase
{
    protected override void Awake()
    {
        type = EvolveTypeSword.Dagger;

        //damage = Axe Damage Here;
        //attackSpeed = Axe Attack Speed Here;
    }

    public override void Enhance()
    {
        //Bonus Damaged based on Distance
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
        //360 Swing
    }

    public override void MeleeSpecial2()
    {
        //Swing On Dash
    }
}
