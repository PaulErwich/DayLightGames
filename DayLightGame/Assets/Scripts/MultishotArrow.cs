using UnityEngine;

public class MultishotArrow : ArrowScript
{
    //Jay

    public Rigidbody2D splinterArrow;

    //Upgrade 2 applied on roll

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.TransformDirection(new Vector2(10, 0));

        //damage = Multishot Arrow Damage here
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (bowSpecial1)
        {
            //Instantiates the three splinter arrows
            Instantiate(splinterArrow, transform.position, transform.rotation);
            Instantiate(splinterArrow, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z - 45, 0));
            Instantiate(splinterArrow, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 45, 0));
        }

        //Destroys the arrow on collision
        Destroy(gameObject);
    }
}
