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

    public void MoveEnemy()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectiles")
        {
            //TakeDamage(collision.gameObject.GetComponent<Arrow>().damage);
        }
    }
}
