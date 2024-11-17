using UnityEngine;

public class ElectricArrow : ArrowScript
{
    //Jay

    RaycastHit2D Hit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.TransformDirection(new Vector2(10, 0));
        type = EvolveTypeBow.Electric;
        slowAmount = 1;
        //damage = Electric Arrow Damage here

        if (enhance)
        {
            slowAmount += 1;
            duration *= 2;
        }

        if (bowSpecial2)
        {
            RaycastHit2D[] Hit = Physics2D.CircleCastAll(transform.position, 10, Vector2.zero);
            //Activate special effect 2
            //Electric trail behind arrow

            foreach (RaycastHit2D ray in Hit)
            {
                //Apply Slow
            }
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroys the arrow on collision
        Destroy(gameObject);

        if (bowSpecial1)
        {
            //Activate special effect 1
            //AOE Slow on enemy hit
        }
    }
}
