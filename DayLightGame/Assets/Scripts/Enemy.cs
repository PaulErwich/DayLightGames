using System.Collections;
using UnityEngine;
using UnityEngine.AI;

//Max

public class Enemy : Character
{
    [Header("Attributes")]
    public int goldWorth;

    NavMeshAgent agent;

    public void SetUpEnemy(int _hitPoints = 10, int _speed = 4, int _armour = 1, int _goldWorth = 1)
    {
        hitPointsMaximum = _hitPoints;
        hitPoints = _hitPoints;
        speed = _speed;
        armour = _armour;
        goldWorth = _goldWorth;
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        if (IsDead())
        {
            Destroy(gameObject);
            Player.instance.GiveGold(goldWorth);
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
        /*
        if (collision.gameObject.tag == "playerArrow")
        {
            ArrowScript arrow = collision.gameObject.GetComponent<ArrowScript>();
            TakeDamage(arrow.damage);
            switch (arrow.evolve)
            {
                case "Burn":
                    Burn(collision.evolve.ticks, collision.evolve.damage);
                    break;
            }
        }
        else if (collision.gameObject.tag == "playerMelee")
        {

        }
        else if (collision.gameObject.tag == "playerFire")
        {

        }
        */
    }

    private void OnDestroy()
    {
        RoomManager.instance.enemiesDestroyed++;
    }
}
