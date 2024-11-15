using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    public static Player instance;

    private Vector2 move;

    private Player(int hitPoints, int speed, int armour) : base(hitPoints, speed, armour) { }

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
        if (collision.gameObject.tag == "EnemyProjectiles")
        {
            //TakeDamage(collision.gameObject.GetComponent<Arrow>().damage);
        }
    }
}
