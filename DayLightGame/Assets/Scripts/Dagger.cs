using UnityEngine;

public class Dagger : MeleeBase
{
    protected override void Awake()
    {
        type = EvolveTypeSword.Dagger;

        //damage = Dagger Damage Here;
        //attackSpeed = Dagger Attack Speed Here;
        //duration = Dagger Bleed Duration;
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
        //Crit enemies below half health
    }

    public override void MeleeSpecial2()
    {
        //Half Dash CD
    }
}
