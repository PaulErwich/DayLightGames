using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Attributes")]
    public int hitPoints;
    public int speed;
    public int armour;
    private Rigidbody rb;

    public Character(int _hitPoints, int _speed, int _armour)
    {
        hitPoints = _hitPoints;
        speed = _speed;
        armour = _armour;
        rb = gameObject.AddComponent<Rigidbody>();
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
