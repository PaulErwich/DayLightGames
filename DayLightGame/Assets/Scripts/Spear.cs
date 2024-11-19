using UnityEngine;

public class Spear : MeleeBase
{
    protected override void Awake()
    {
        type = EvolveTypeSword.Dagger;

        //damage = Spear Damage Here;
        //attackSpeed = Spear Attack Speed Here;
        //duration = Spear Bleed Duration;

        Player.leftHand.localPosition = new Vector3(0.238f, 0.724f, 0f);
        Player.leftHand.localRotation = new Quaternion(0f, 0f, 31.46f, 0f);

        Player.rightHand.localPosition = new Vector3(0.588f, 0.161f, 0f);
        Player.rightHand.localRotation = new Quaternion(0f, 0f, 0f, 0f);
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
