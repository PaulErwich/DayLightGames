using System.Collections;
using UnityEngine;

//Max

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

    protected virtual void Awake()
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

    public IEnumerator Burn(int amount, int ticks)
    {
        for (int i = 0; i < ticks ; i++)
        {
            yield return new WaitForSeconds(1);
            TakeDamage(amount);
        }
    }

    public IEnumerator Slow(float duration, int slowedSpeed)
    {
        int baseSpeed = speed;
        yield return StartCoroutine(newSpeed(duration, slowedSpeed));
        yield return resetSpeed(baseSpeed);
    }

    private IEnumerator newSpeed(float duration, int slowedSpeed)
    {
        speed -= slowedSpeed;
        yield return new WaitForSeconds(duration);
    }

    private IEnumerator resetSpeed(int baseSpeed)
    {
        yield return speed = baseSpeed;
    }
}
