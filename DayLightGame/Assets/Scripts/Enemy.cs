using UnityEngine;

public class Enemy : Character
{
    [Header("Attributes")]
    private int goldWorth;

    private Enemy(int hitPoints, int speed, int armour, int goldWorth) : base(hitPoints, speed, armour) { }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        if (IsDead())
        {
            Destroy(gameObject);
            // Currency += goldWorth
        }
    }

    private void FixedUpdate()
    {
        
    }
}
