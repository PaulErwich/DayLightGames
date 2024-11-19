using UnityEngine;

public class Shield : MeleeBase
{
    protected override void Awake()
    {
        type = EvolveTypeSword.Dagger;

        //damage = Shield Damage Here;
        //attackSpeed = Shield Attack Speed Here;
        //duration = Shield Stun Duration;

        Player.leftHand.localPosition = new Vector3(-0.5f, 0.5f, 0f);
        Player.leftHand.localRotation = new Quaternion(0f, 0f, 0f, 0f);

        Player.rightHand.localPosition = new Vector3(0.238f, 0.634f, 0f);
        Player.rightHand.localRotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    public override void Enhance()
    {
        //Wider Shield

        Player.leftHand.localPosition = new Vector3(-0.351f, 0.5f, 0f);

        Player.rightHand.localPosition = new Vector3(0.374f, 0.5f, 0f);
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
