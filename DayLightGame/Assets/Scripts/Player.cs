using UnityEngine;
using UnityEngine.InputSystem;

//Max

public class Player : Character
{
    public static Player instance;

    private Vector2 move;

    private int gold;

    protected override void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        base.Awake();
    }

    public void StatUpgrade(statUpgradeType type, int amount)
    {
        switch (type)
        {
            case statUpgradeType.Health:
                hitPointsMaximum += amount;
                hitPoints += amount;
                break;
            case statUpgradeType.AttackSpeed:
                // On weapon
                break;
            case statUpgradeType.Speed:
                speed += amount;
                break;
            case statUpgradeType.Armour:
                armour += amount;
                break;
        }
    }

    public bool TakeGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GiveGold(int amount)
    {
        gold += amount;
    }

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    private void OnMeleeAttack(InputValue value)
    {
        Debug.Log("Left");
    }

    private void OnRangedAttack(InputValue value)
    {
        Debug.Log("Right");
    }

    private void FixedUpdate()
    {
        Vector2 currentPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, move + currentPos, speed * Time.deltaTime);
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        if (IsDead())
        {
            // Death Logic
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.tag == "enemyArrow")
        {
            TakeDamage(collision.gameObject.GetComponent<ArrowScript>().damage);
        }
        else if (collision.gameObject.tag == "enemyMelee")
        {
            TakeDamage(collision.gameObject.GetComponent<Sword>().damage);
        }
        */
    }
}
