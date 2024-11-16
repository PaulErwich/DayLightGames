using UnityEngine;

public class ExplosiveArrow : ArrowScript
{
    //Jay

    RaycastHit2D Hit;

    public Rigidbody2D clusterBomb;

    public float blastRadius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.TransformDirection(new Vector2(10, 0));

        //damage = Explosive Arrow Damage here

        if (enhance)
        {
            blastRadius *= 2;
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        //Do explosion
        RaycastHit2D[] Hit = Physics2D.CircleCastAll(transform.position, blastRadius, Vector2.zero);

        foreach (RaycastHit2D ray in Hit)
        {
            //Apply explosive damage
        }

        if (bowSpecial1)
        {
            //Spawns cluster bombs
            Instantiate(clusterBomb, new Vector2(transform.position.x - 1, transform.position.y + 2), transform.rotation);
            Instantiate(clusterBomb, new Vector2(transform.position.x + 1, transform.position.y + 2), transform.rotation);
            Instantiate(clusterBomb, new Vector2(transform.position.x - 2, transform.position.y), transform.rotation);
            Instantiate(clusterBomb, new Vector2(transform.position.x + 2, transform.position.y), transform.rotation);
            Instantiate(clusterBomb, new Vector2(transform.position.x - 1, transform.position.y - 2), transform.rotation);
            Instantiate(clusterBomb, new Vector2(transform.position.x + 1, transform.position.y - 2), transform.rotation);
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
