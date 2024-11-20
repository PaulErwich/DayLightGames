using UnityEngine;

public class Gauntlets : MeleeBase
{
    protected override void Awake()
    {
        type = EvolveTypeSword.Dagger;

        //damage = Dagger Damage Here;
        //attackSpeed = Dagger Attack Speed Here;
        //duration = Gauntlets Slow Duration;

        Player.leftHand.localPosition = new Vector3(-0.5f, 0.5f, 0f);
        Player.leftHand.localRotation = new Quaternion(0f, 0f, 0f, 0f);

        Player.rightHand.localPosition = new Vector3(0.5f, 0.5f, 0f);
        Player.rightHand.localRotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    public override void Enhance()
    {
        //Dual hit on third attack
        swingType = "gauntletsBig";
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
        Player.instance.dashPower *= 2;
        Player.instance.dashTime *= 2;
    }

    public override void MeleeSpecial2()
    {
        //Apply Electric On Hit
        element = "electric";
    }
}
