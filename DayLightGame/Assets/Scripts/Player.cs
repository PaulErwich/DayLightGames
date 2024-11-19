using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

//Max

public class Player : Character
{
    public static Player instance;
    public static Transform leftHand;
    public static Transform rightHand;

    private BowScript bow;
    private MeleeBase mb;

    [SerializeField] public Transform pivotPoint;

    private Vector2 move;

    private int gold;

    public int meleeKillCount;
    public int rangedKillCount;
    public int requiredKillsMelee = 1;
    public int requiredKillsRanged = 1;

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
        leftHand = this.transform.Find("Pivot Left Hand");
        leftHand = this.transform.Find("Pivot Right Hand");
        base.Awake();
        baseSpeed = speed;
        cc.excludeLayers = LayerMask.GetMask("Weapons");
    }

    private void Start()
    {
        bow = GetComponentInChildren<BowScript>();
        mb = GetComponentInChildren<MeleeBase>();
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
                mb.attackSpeed += amount;
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
        mb.Hit();
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
            //gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemyArrow")
        {
            TakeDamage(collision.gameObject.GetComponent<ArrowScript>().damage);
        }
        else if (collision.collider.gameObject.tag == "enemyMelee")
        {
            TakeDamage(collision.collider.gameObject.GetComponent<MeleeBase>().damage);
        }
    }

    public EvolveTypeBow GetBowEvolve()
    {
        return bow.GetEvolveType();
    }

    public EvolveTypeSword GetSwordEvolve()
    {
        return mb.GetEvolveType();
    }

    public void IncreaseKillCount(weaponType type)
    {
        Debug.Log("Increase count " + type);
        if (type == weaponType.melee)
            meleeKillCount++;
        else if (type == weaponType.ranged)
            rangedKillCount++;
    }
}
