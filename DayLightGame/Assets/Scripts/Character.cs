using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Attributes")]
    public int hitPoints;
    public int speed;
    public int armour;
    private Rigidbody2D rb;
    private CircleCollider2D cc;

    public Character(int _hitPoints, int _speed, int _armour)
    {
        hitPoints = _hitPoints;
        speed = _speed;
        armour = _armour;
    }

    private void Awake()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        cc = gameObject.AddComponent<CircleCollider2D>();
    }

    public virtual void TakeDamage(int amount)
    {
        if (amount < armour)
        {
            hitPoints -= 1;
        }
        else
        {
            hitPoints -= amount - armour;
        }
    }

    public bool IsDead()
    {
        return hitPoints <= 0;
    }
}
