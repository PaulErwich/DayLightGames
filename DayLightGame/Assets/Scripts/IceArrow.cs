using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : ArrowScript
{
    //Jay

    RaycastHit2D Hit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.TransformDirection(new Vector2(10, 0));
        type = EvolveTypeBow.Ice;
        //damage = Ice Arrow Damage here

        if (enhance)
        {
            duration *= 2;
        }

        if (bowSpecial2)
        {
            //Activate special effect 2
            //Freeze trail behind arrow
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (bowSpecial1)
        {
            RaycastHit2D[] Hit = Physics2D.CircleCastAll(transform.position, 10, Vector2.zero);
            //Activate special effect 1
            //AOE Freeze on enemy hit

            foreach (RaycastHit2D ray in Hit)
            {
                //Apply freeze
            }
        }

        //Destroys the arrow on collision
        Destroy(gameObject);
    }
}
