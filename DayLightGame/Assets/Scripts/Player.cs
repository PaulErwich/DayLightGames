using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

//Max

public class Player : Character
{
    public static Player instance;

    private BowScript bow;
    private Sword sword;

    [SerializeField] private Transform pivotPoint;

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
        baseSpeed = speed;
    }

    private void Start()
    {
        bow = GetComponentInChildren<BowScript>();
        sword = GetComponentInChildren<Sword>();
    }

    // Stat upgrades using the shop and level up menus
    public void StatUpgrade(statUpgradeType type, int amount)
    {
        switch (type)
        {
            case statUpgradeType.MaxHealth:
                hitPointsMaximum += amount;
                hitPoints += amount;
                break;
            case statUpgradeType.AttackSpeed:
                bow.bowAtkSpeed += amount;
                break;
            case statUpgradeType.Speed:
                speed += amount;
                baseSpeed = speed;
                break;
            case statUpgradeType.Armour:
                armour += amount;
                break;
        }
    }

    // Check if there is enough gold and remove if true
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

    public int GetGold()
    {
        return gold;
    }

    public int GetCurrentHealth()
    {
        return hitPoints;
    }

    public int GetMaxHealth()
    {
        return hitPointsMaximum;
    }

    public int GetMissingHealth()
    {
        return hitPointsMaximum - hitPoints;
    }

    public void RestoreHealth(int amount)
    {
        if (amount < GetMissingHealth())
        {
            hitPoints += amount;
        }
        else
        {
            hitPoints = hitPointsMaximum;
        }
    }

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    private void OnMeleeAttack(InputValue value)
    {
        sword.Swing();
    }

    private void OnRangedAttack(InputValue value)
    {
        bow.Shoot();
    }

    private void FixedUpdate()
    {
        Vector2 currentPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, move + currentPos, speed * Time.deltaTime);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z += 90;
        pivotPoint.LookAt(mousePos, new Vector3(0, 0, -1));
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
        if (collision.gameObject.tag == "enemyArrow")
        {
            TakeDamage(collision.gameObject.GetComponent<ArrowScript>().damage);
        }
        /*
        else if (collision.gameObject.tag == "enemyMelee")
        {
            TakeDamage(collision.gameObject.GetComponent<Sword>().damage);
        }
        */
    }
}
