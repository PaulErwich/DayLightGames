using UnityEngine;

public class MultishotArrow : ArrowScript
{
    //Jay

    public BowScript bowScript;

    //Upgrade 2 applied on roll

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.TransformDirection(new Vector2(10, 0));
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (bowSpecial1)
        {
            //Activate special effect 1
            //Arrows splinter on enemy hit
        }

        //Destroys the arrow on collision
        Destroy(gameObject);
    }
}
