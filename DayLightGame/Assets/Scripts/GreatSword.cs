using UnityEngine;

public class GreatSword : MeleeBase
{
    protected override void Awake()
    {
        type = EvolveTypeSword.Dagger;

        //damage = Great Sword Damage Here;
        //attackSpeed = Great Sword Attack Speed Here;

        Player.leftHand.localPosition = new Vector3(-0.5f, 0.5f, 0f);
        Player.leftHand.localRotation = new Quaternion(0f, 0f, 0f, 0f);

        Player.rightHand.localPosition = new Vector3(-0.5f, 0.5f, 0f);
        Player.rightHand.localRotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    public override void Enhance()
    {
        //Increased Range
        Player.rightHand.GetChild(1).transform.localPosition = new Vector3(0f, 0.73f, 0f);
        Player.rightHand.GetChild(1).transform.localScale = new Vector3(1f, 1.7f, 1f);
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
        //Chance To Crit
    }

    public override void MeleeSpecial2()
    {
        //Destroy Projectiles
    }
}
