using System.Collections;
using UnityEngine;

//Max

public class Character : MonoBehaviour
{
    [Header("Attributes")]
    public int hitPointsMaximum;
    public int hitPoints;
    public int baseSpeed = 10;
    public int speed;
    public int armour;
    protected Rigidbody2D rb;
    protected CircleCollider2D cc;

    private int coroutineCount = 0;

    // Apply a rigidbody and circle collider to the character
    protected virtual void Awake()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.mass = 1000000;
        rb.inertia = 1000000;
        cc = gameObject.AddComponent<CircleCollider2D>();
    }

    protected virtual void LateUpdate()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0.0f;
        rb.rotation = 0.0f;
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
    public IEnumerator Burn(float duration, int amount)
    {
        for (int i = 0; i < duration ; i++)
        {
            yield return new WaitForSeconds(1f);
            TakeDamage(amount);
        }
    }

    // Slow the character
    public virtual void Slow(float duration, int slowedSpeed)
    {
        coroutineCount++;
        SetSpeed(baseSpeed - slowedSpeed);
        StartCoroutine(resetSpeed(duration));
    }

    private IEnumerator resetSpeed(float duration)
    {
        yield return new WaitForSeconds(duration);
        coroutineCount--;
        CheckCoroutine();
    }

    private void CheckCoroutine()
    {
        if (coroutineCount <= 0)
        {
            SetSpeed(baseSpeed);
        }
    }

    public virtual int GetSpeed()
    {
        return speed;
    }

    public virtual void SetSpeed(int newSpeed)
    {
        speed = newSpeed;
    }
}
