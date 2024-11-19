using UnityEngine;

public class Dagger : MeleeBase
{
    protected override void Awake()
    {
        type = EvolveTypeSword.Dagger;

        //damage = Dagger Damage Here;
        //attackSpeed = Dagger Attack Speed Here;
        //duration = Dagger Bleed Duration;

        Player.leftHand.localPosition = new Vector3(-0.5f, 0.5f, 0f);
        Player.leftHand.localRotation = new Quaternion(0f, 0f, 0f, 0f);

        Player.rightHand.localPosition = new Vector3(-0.5f, 0.5f, 0f);
        Player.rightHand.localRotation = new Quaternion(0f, 0f, 0f, 0f);

        element = "bleed";
        elementDamage = 1;
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
        //Crit enemies below half health --
    }

    public override void MeleeSpecial2()
    {
        //Half Dash CD
    }
}
