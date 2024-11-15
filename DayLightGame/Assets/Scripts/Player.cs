using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    private Vector2 move;

    private Player(int hitPoints, int speed, int armour) : base(hitPoints, speed, armour) { }

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
}
