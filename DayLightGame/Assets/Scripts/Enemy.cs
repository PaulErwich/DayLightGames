using System.Collections;
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
    }

    private void FixedUpdate()
    {
        GetTargetPosition();

        // Only rotates the z axis
        
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerArrow")
        {
            ArrowScript arrow = collision.gameObject.GetComponent<ArrowScript>();
            TakeDamage(arrow.damage);
            switch (arrow.type)
            {
                case EvolveTypeBow.Fire:
                    StartCoroutine(Burn(arrow.duration, arrow.damage));
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
            MeleeBase weapon = collision.collider.gameObject.GetComponent<MeleeBase>();
            TakeDamage(weapon.damage);
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
