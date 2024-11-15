using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [Header("Attributes")]
    private int goldWorth;

    NavMeshAgent agent;

    private Enemy(int hitPoints, int speed, int armour, int goldWorth) : base(hitPoints, speed, armour) { }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        if (IsDead())
        {
            Destroy(gameObject);
            // Currency += goldWorth
        }
    }

    private void Start()
    {
        agent = gameObject.AddComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.acceleration = 50;
        agent.speed = speed;
    }

    private void FixedUpdate()
    {
        GetTargetPosition();
    }

    private void GetTargetPosition()
    {
        Vector2 playerPos = Player.instance.transform.position;
        agent.SetDestination(playerPos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectiles")
        {
            //TakeDamage(collision.gameObject.GetComponent<Arrow>().damage);
        }
    }
}
