using System.Collections;
using UnityEngine;

//Max

public class Character : MonoBehaviour
{
    [Header("Attributes")]
    public int hitPointsMaximum;
    public int hitPoints;
    public int speed;
    public int armour;
    private Rigidbody2D rb;
    private CircleCollider2D cc;

    // Apply a rigidbody and circle collider to the character
    protected virtual void Awake()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        cc = gameObject.AddComponent<CircleCollider2D>();
    }

    // Deal damage to the character - armour
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

    // Check if the character is dead
    public bool IsDead()
    {
        return hitPoints <= 0;
    }

    // Deal buring damage over so many ticks
    public IEnumerator Burn(int amount, int ticks)
    {
        for (int i = 0; i < ticks ; i++)
        {
            yield return new WaitForSeconds(0.5f);
            TakeDamage(amount);
        }
    }

    // Slow the character
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
