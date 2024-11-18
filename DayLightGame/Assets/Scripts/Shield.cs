using UnityEngine;

public class Shield : MeleeBase
{
    protected override void Awake()
    {
        type = EvolveTypeSword.Dagger;

        //damage = Shield Damage Here;
        //attackSpeed = Shield Attack Speed Here;
        //duration = Shield Stun Duration;
    }

    public override void Enhance()
    {
        //Wider Shield
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
        //Reflect Damage When Shield Is Hit
    }

    public override void MeleeSpecial2()
    {
        //Apply Ice To Enemies Hit
    }
}
