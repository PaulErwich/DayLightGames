using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

//Max

public class Enemy : Character
{
    [Header("Attributes")]
    public int goldWorth;

    [SerializeField] private Transform pivotPoint;

    NavMeshAgent agent;
    Animator am;

    private float cooldown;
    private float attackSpeed = 0.5f;
    private string lastHitTag;

    // Set stats for the created enemy
    public void SetUpEnemy(int _hitPoints = 10, int _speed = 4, int _armour = 1, int _goldWorth = 1)
    {
        hitPointsMaximum = _hitPoints;
        hitPoints = _hitPoints;
        speed = _speed;
        baseSpeed = _speed;
        armour = _armour;
        goldWorth = _goldWorth;
    }

    // Take damage override
    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        if (IsDead())
        {
            Destroy(gameObject);
            Player.instance.GiveGold(goldWorth);
            if (lastHitTag == "playerArrow")
                Player.instance.IncreaseKillCount(weaponType.ranged);
            else if (lastHitTag == "playerMelee")
                Player.instance.IncreaseKillCount(weaponType.melee);
        }
    }

    // Set the NavMesh agent on the enemy
    private void Start()
    {
        agent = gameObject.AddComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.acceleration = 50;
        agent.speed = speed;
        agent.angularSpeed = speed;

        am = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        GetTargetPosition();
        cooldown += Time.deltaTime;
    }

    // Set the target of the NavMesh
    private void GetTargetPosition()
    {
        Vector2 playerPos = Player.instance.transform.position;
        agent.SetDestination(playerPos);

        Vector3 velocity = agent.velocity;
        velocity.z = 0;

        if (velocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, velocity);
            pivotPoint.rotation = Quaternion.RotateTowards(pivotPoint.rotation, targetRotation, 3);
        }

        if (Vector2.Distance(pivotPoint.position, playerPos) <= 2f * transform.localScale.x && cooldown >= 1 / attackSpeed)
        {
            am.SetTrigger("slash");
            cooldown = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerArrow")
        {
            lastHitTag = collision.gameObject.tag;
            ArrowScript arrow = collision.gameObject.GetComponent<ArrowScript>();
            TakeDamage(arrow.damage);
            switch (arrow.type)
            {
                case EvolveTypeBow.Fire:
                    StartCoroutine(DOT(arrow.duration, arrow.damage));
                    break;
                case EvolveTypeBow.Ice:
                    Slow(arrow.duration, GetSpeed());
                    break;
                case EvolveTypeBow.Electric:
                    Slow(arrow.duration, arrow.slowAmount);
                    break;
            }
        }
        else if (collision.collider.gameObject.tag == "playerMelee")
        {
            lastHitTag = collision.collider.gameObject.tag;
            MeleeBase weapon = collision.collider.gameObject.GetComponent<MeleeBase>();
            TakeDamage(weapon.damage);
            // Crits
            if ((weapon.type == EvolveTypeSword.Dagger && weapon.meleeSpecial1 == true && hitPoints < hitPoints / 2) || 
                (weapon.type == EvolveTypeSword.GreatSword && weapon.meleeSpecial1 == true && Random.Range(0, 20) == 0))
            {
                TakeDamage(weapon.damage);
            }
            switch (weapon.element)
            {
                case null:
                    break;
                case "bleed":
                    StartCoroutine(DOT(weapon.duration, weapon.elementDamage));
                    break;
                case "ice":
                    Slow(weapon.duration, GetSpeed());
                    break;
                case "electric":
                    Slow(weapon.duration, weapon.slowAmount);
                    break;
            }
        }
        else if (collision.gameObject.tag == "playerFire")
        {

        }
    }

    private void OnDestroy()
    {
        RoomManager.instance.enemiesDestroyed++;
    }

    public override int GetSpeed()
    {
        return (int)agent.speed;
    }

    public override void SetSpeed(int newSpeed)
    {
        agent.speed = newSpeed;
    }
}
