using UnityEngine;

public class ElectricArrow : ArrowScript
{
    //Jay

    public BowScript bowScript;
    RaycastHit2D Hit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.TransformDirection(new Vector2(10, 0));

        if (enhance)
        {
            duration *= 2;
        }

        if (bowSpecial2)
        {
            RaycastHit2D[] Hit = Physics2D.CircleCastAll(transform.position, 10, Vector2.zero);
            //Activate special effect 2
            //Electric trail behind arrow

            foreach (RaycastHit2D ray in Hit)
            {

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

    // Update is called once per frame
    void Update()
    {

    }
}
