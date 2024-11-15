using UnityEngine;

public class CrossbowArrow : ArrowScript
{
    //Jay

    private int pierceCount;
    private int pierceTotal;
    private bool firstHit = false;

    public BowScript bowScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        pierceCount = 0;
        pierceTotal = 3;

        if (enhance)
        {
            pierceTotal *= 2;
            //Increases pierce
        }

        GetComponent<Rigidbody2D>().linearVelocity = transform.TransformDirection(new Vector2(10, 0));
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        pierceCount += 1;

        if (bowSpecial1 && firstHit)
        {
            firstHit = false;
            //Increase damage by 100%
        }

        if (bowSpecial2)
        {
            //Apply knockback to enemies
        }

        if (pierceCount >= pierceTotal)
        {
            //Destroys the arrow on collision
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
