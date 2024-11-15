using UnityEngine;

public class ExplosiveArrow : ArrowScript
{
    //Jay

    public BowScript bowScript;
    RaycastHit2D Hit;

    private float blastRadius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.TransformDirection(new Vector2(10, 0));

        if (enhance)
        {
            blastRadius *= 2;
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        //Do explosion
        RaycastHit2D[] Hit = Physics2D.CircleCastAll(transform.position, blastRadius, Vector2.zero);
        //Activate special effect 2
        //Electric trail behind arrow

        foreach (RaycastHit2D ray in Hit)
        {

        }

        if (bowSpecial1)
        {
            //Activate special effect 1
            //Cluster bombs on enemy hit
        }

        if (bowSpecial2)
        {
            //Activate special effect 2
            //Gravity bomb on enemy hit
        }

        //Destroys the arrow on collision
        Destroy(gameObject);
    }
}
