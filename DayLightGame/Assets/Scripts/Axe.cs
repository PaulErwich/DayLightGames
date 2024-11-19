using UnityEngine;

public class Axe : MeleeBase
{
    protected override void Awake()
    {
        type = EvolveTypeSword.Dagger;

        //damage = Axe Damage Here;
        //attackSpeed = Axe Attack Speed Here;

        Player.leftHand.localPosition = new Vector3(-0.232f, 0.607f, 0f);
        Player.leftHand.localRotation = new Quaternion(0f, 0f, 0f, 0f);

        Player.rightHand.localPosition = new Vector3(0.287f, 0.645f, 0f);
        Player.rightHand.localRotation = new Quaternion(0f, 0f, 0f, -84.637f);
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
        swingType = "axeSpin";
    }

    public override void MeleeSpecial2()
    {
        //Swing On Dash
    }
}
